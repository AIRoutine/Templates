namespace AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;

/// <summary>
/// Request to refresh authentication tokens.
/// </summary>
public record RefreshRequest : IRequest<RefreshResponse>;

/// <summary>
/// Response from token refresh attempt.
/// </summary>
public record RefreshResponse(bool Success, string? ErrorMessage = null)
{
    public static RefreshResponse Fail(string message) => new(false, message);
    public static RefreshResponse Successful() => new(true);
}
