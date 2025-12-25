namespace AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;

/// <summary>
/// Request to initiate sign-in with a specific authentication scheme.
/// </summary>
public record SignInRequest(string Scheme) : IRequest<SignInResponse>;

/// <summary>
/// Response from sign-in attempt.
/// </summary>
public record SignInResponse(bool Success, string? ErrorMessage = null)
{
    public static SignInResponse Fail(string message) => new(false, message);
    public static SignInResponse Successful() => new(true);
}
