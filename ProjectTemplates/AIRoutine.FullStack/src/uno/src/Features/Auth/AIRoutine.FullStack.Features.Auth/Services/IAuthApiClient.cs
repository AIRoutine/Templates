namespace AIRoutine.FullStack.Features.Auth.Services;

/// <summary>
/// Client for communicating with the authentication API endpoints.
/// </summary>
public interface IAuthApiClient
{
    /// <summary>
    /// Signs in with the specified authentication scheme.
    /// </summary>
    Task<ApiSignInResponse> SignInAsync(string scheme, CancellationToken cancellationToken = default);

    /// <summary>
    /// Refreshes the authentication tokens.
    /// </summary>
    Task<ApiRefreshResponse> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs out and invalidates the tokens.
    /// </summary>
    Task SignOutAsync(string refreshToken, string? pushToken = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// API response for sign-in operation.
/// </summary>
public record ApiSignInResponse(bool Success, string? Jwt, string? RefreshToken, string? Email, string? DisplayName, string? ErrorMessage);

/// <summary>
/// API response for token refresh operation.
/// </summary>
public record ApiRefreshResponse(bool Success, string? Jwt, string? RefreshToken, string? ErrorMessage);
