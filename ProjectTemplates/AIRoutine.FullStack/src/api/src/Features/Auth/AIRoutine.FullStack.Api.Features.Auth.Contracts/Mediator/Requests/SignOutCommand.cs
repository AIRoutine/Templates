namespace AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;

public record SignOutCommand(
    string RefreshToken,
    string? PushToken
) : Shiny.Mediator.ICommand;
