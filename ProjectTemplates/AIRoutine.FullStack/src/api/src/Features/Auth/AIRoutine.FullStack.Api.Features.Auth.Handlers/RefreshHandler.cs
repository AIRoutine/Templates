using AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Api.Features.Auth.Data;
using AIRoutine.FullStack.Api.Features.Auth.Services;
using Microsoft.EntityFrameworkCore;

namespace AIRoutine.FullStack.Api.Features.Auth.Handlers;

[MediatorScoped]
public class RefreshHandler(AuthDbContext data, JwtService jwtService) : IRequestHandler<RefreshRequest, RefreshResponse>
{
    [MediatorHttpPost(
        "RefreshAuth",
        "/auth/signin/refresh",
        RequiresAuthorization = true
    )]
    public async Task<RefreshResponse> Handle(RefreshRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        var result = await jwtService
            .ValidateRefreshToken(request.Token, cancellationToken)
            .ConfigureAwait(false);

        if (!result)
            return RefreshResponse.Fail;

        var refreshToken = await data
            .RefreshTokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == request.Token, cancellationToken);

        if (refreshToken == null)
            return RefreshResponse.Fail;

        var tokens = await jwtService.CreateJwt(refreshToken.User, cancellationToken);

        return RefreshResponse.Successful(tokens.Jwt, tokens.RefreshToken);
    }
}
