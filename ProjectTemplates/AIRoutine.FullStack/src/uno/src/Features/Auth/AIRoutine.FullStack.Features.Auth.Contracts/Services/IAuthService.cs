namespace AIRoutine.FullStack.Features.Auth.Contracts.Services;

/// <summary>
/// Service for managing authentication state and tokens.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Gets whether the user is currently authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the current JWT token, if available.
    /// </summary>
    string? CurrentToken { get; }

    /// <summary>
    /// Gets the current user's email, if authenticated.
    /// </summary>
    string? UserEmail { get; }

    /// <summary>
    /// Gets the current user's display name, if authenticated.
    /// </summary>
    string? DisplayName { get; }

    /// <summary>
    /// Sets the authentication tokens after successful sign-in.
    /// </summary>
    Task SetTokensAsync(string jwt, string refreshToken, string email, string? displayName = null);

    /// <summary>
    /// Clears all stored authentication data.
    /// </summary>
    Task ClearTokensAsync();

    /// <summary>
    /// Gets the stored refresh token.
    /// </summary>
    Task<string?> GetRefreshTokenAsync();

    /// <summary>
    /// Initializes the authentication state from stored tokens.
    /// </summary>
    Task InitializeAsync();
}
