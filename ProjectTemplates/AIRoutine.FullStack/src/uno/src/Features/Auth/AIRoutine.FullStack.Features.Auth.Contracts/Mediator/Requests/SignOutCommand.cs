namespace AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;

/// <summary>
/// Command to sign out the current user.
/// </summary>
public record SignOutCommand : Shiny.Mediator.ICommand;
