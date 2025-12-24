using System.Security.Claims;
using AIRoutine.FullStack.Api.Core.Data;
using AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Api.Features.Auth.Data.Entities;
using AIRoutine.FullStack.Api.Features.Auth.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AIRoutine.FullStack.Api.Features.Auth.Handlers;

[MediatorScoped]
public class SignInHandler(
    AppDbContext data,
    JwtService jwtService,
    IHttpContextAccessor httpAccessor
) : IRequestHandler<SignInRequest, SignInResponse>
{
    [MediatorHttpPost(
        "/auth/signin/mobile",
        OperationId = "SignIn",
        AllowAnonymous = true
    )]
    public async Task<SignInResponse> Handle(SignInRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
#if DEBUG
        if (request.Scheme.StartsWith("HACK:", StringComparison.InvariantCultureIgnoreCase))
        {
            var email1 = request.Scheme.Split(":")[1];
            var user1 = await data.Set<User>().FirstOrDefaultAsync(x => x.Email == email1, cancellationToken);

            if (user1 == null)
                return SignInResponse.Fail;

            var uritest = await this.CreateTokenToApp(user1!, false, cancellationToken);
            return SignInResponse.Successful(uritest);
        }
#endif
        var auth = await httpAccessor.HttpContext!.AuthenticateAsync(request.Scheme);

        if (!auth.Succeeded
            || auth?.Principal == null
            || !auth.Principal.Identities.Any(id => id.IsAuthenticated)
            || string.IsNullOrEmpty(auth.Properties.GetTokenValue("access_token")))

            return SignInResponse.Fail;

        var newUser = false;
        var claims = auth.Principal.Identities.FirstOrDefault()?.Claims.ToList();
        var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var user = await data.Set<User>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        if (user == null)
        {
            newUser = true;
            user = new User
            {
                Id = Guid.NewGuid(),
                Email = email
            };
            data.Set<User>().Add(user);
        }
        user.FirstName = claims!.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
        user.LastName = claims!.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value ?? string.Empty;
        await data.SaveChangesAsync(cancellationToken);

        var uri = await this.CreateTokenToApp(user, newUser, cancellationToken);
        return SignInResponse.Successful(uri);
    }

    async Task<string> CreateTokenToApp(User user, bool newUser, CancellationToken cancellationToken)
    {
        var tokens = await jwtService.CreateJwt(user, cancellationToken);
        var url = $"myapp://#newuser={newUser}&access_token={tokens.Jwt}&refresh_token={tokens.RefreshToken}";

        return url;
    }
}
