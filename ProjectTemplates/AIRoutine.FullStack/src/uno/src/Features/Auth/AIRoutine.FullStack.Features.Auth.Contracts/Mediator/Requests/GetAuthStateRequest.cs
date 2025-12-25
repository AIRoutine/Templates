namespace AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;

/// <summary>
/// Request to get the current authentication state.
/// </summary>
public record GetAuthStateRequest : IRequest<AuthState>;

/// <summary>
/// Represents the current authentication state.
/// </summary>
public record AuthState(bool IsAuthenticated, string? UserEmail = null, string? DisplayName = null)
{
    public static AuthState Anonymous { get; } = new(false);
    public static AuthState Authenticated(string email, string? displayName = null) => new(true, email, displayName);
}
