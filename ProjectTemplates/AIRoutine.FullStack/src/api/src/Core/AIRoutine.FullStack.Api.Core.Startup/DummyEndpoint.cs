namespace AIRoutine.FullStack.Api.Core.Startup;

/// <summary>
/// This class is only here to force the MediatorHttpPost attribute to be included in the build.
/// And so we can use AddMediatorRegistry here: services.AddShinyMediator(x => x.AddMediatorRegistry()); in ServiceCollectionExtensions.cs
/// </summary>
[MediatorScoped]
public class DummyCommandHandler() : ICommandHandler<DummyCommand>
{
    [MediatorHttpPost(
        "/auth/signout",
        OperationId = "SignOut",
        RequiresAuthorization = true
    )]
    public async Task Handle(DummyCommand command, IMediatorContext context, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class DummyCommand : ICommand;