using AIRoutine.FullStack.Api.Core.Data;
using AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Api.Features.Auth.Data.Entities;
using AIRoutine.FullStack.Api.Features.Auth.Services;
using Microsoft.EntityFrameworkCore;

namespace AIRoutine.FullStack.Api.Features.Auth.Handlers;

[MediatorScoped]
public class SignOutHandler(AppDbContext data, IUserService user) : ICommandHandler<SignOutCommand>
{
    [MediatorHttpPost(
        "/auth/signout",
        OperationId = "SignOut",
        RequiresAuthorization = true
    )]
    public async Task Handle(SignOutCommand command, IMediatorContext context, CancellationToken cancellationToken)
    {
        var userId = user.UserId;
        await data
            .Set<RefreshToken>()
            .Where(x =>
                x.UserId == userId &&
                x.Token == command.RefreshToken
            )
            .ExecuteDeleteAsync(cancellationToken);
    }
}
