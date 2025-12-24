using AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Api.Features.Auth.Data;
using AIRoutine.FullStack.Api.Features.Auth.Services;
using Microsoft.EntityFrameworkCore;

namespace AIRoutine.FullStack.Api.Features.Auth.Handlers;

[MediatorScoped]
public class SignOutHandler(AuthDbContext data, IUserService user) : ICommandHandler<SignOutCommand>
{
    [MediatorHttpPost(
        "SignOut",
        "/auth/signout",
        RequiresAuthorization = true
    )]
    public async Task Handle(SignOutCommand command, IMediatorContext context, CancellationToken cancellationToken)
    {
        var userId = user.UserId;
        await data
            .RefreshTokens
            .Where(x =>
                x.UserId == userId &&
                x.Id == command.RefreshToken
            )
            .ExecuteDeleteAsync(cancellationToken);
    }
}
