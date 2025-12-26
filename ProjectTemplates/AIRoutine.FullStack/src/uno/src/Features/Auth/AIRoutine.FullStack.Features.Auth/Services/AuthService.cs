using Microsoft.Extensions.Logging;
using Uno.Extensions.Storage;

namespace AIRoutine.FullStack.Features.Auth.Services;

/// <summary>
/// Implementation of <see cref="IAuthService"/> using secure storage.
/// </summary>
public sealed class AuthService : IAuthService
{
    private const string JwtTokenKey = "auth_jwt_token";
    private const string RefreshTokenKey = "auth_refresh_token";
    private const string UserEmailKey = "auth_user_email";
    private const string DisplayNameKey = "auth_display_name";

    private readonly IKeyValueStorage _storage;
    private readonly ILogger<AuthService> _logger;

    private string? _currentToken;
    private string? _userEmail;
    private string? _displayName;
    private bool _isInitialized;

    public AuthService(IKeyValueStorage storage, ILogger<AuthService> logger)
    {
        _storage = storage;
        _logger = logger;
    }

    public bool IsAuthenticated => !string.IsNullOrEmpty(_currentToken);

    public string? CurrentToken => _currentToken;

    public string? UserEmail => _userEmail;

    public string? DisplayName => _displayName;

    public async Task InitializeAsync()
    {
        if (_isInitialized)
        {
            return;
        }

        try
        {
            _currentToken = await _storage.GetStringAsync(JwtTokenKey, CancellationToken.None);
            _userEmail = await _storage.GetStringAsync(UserEmailKey, CancellationToken.None);
            _displayName = await _storage.GetStringAsync(DisplayNameKey, CancellationToken.None);
            _isInitialized = true;

            _logger.LogInformation("Auth state initialized. IsAuthenticated: {IsAuthenticated}", IsAuthenticated);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to initialize auth state from storage");
        }
    }

    public async Task SetTokensAsync(string jwt, string refreshToken, string email, string? displayName = null)
    {
        try
        {
            await _storage.SetAsync(JwtTokenKey, jwt, CancellationToken.None);
            await _storage.SetAsync(RefreshTokenKey, refreshToken, CancellationToken.None);
            await _storage.SetAsync(UserEmailKey, email, CancellationToken.None);

            if (!string.IsNullOrEmpty(displayName))
            {
                await _storage.SetAsync(DisplayNameKey, displayName, CancellationToken.None);
            }

            _currentToken = jwt;
            _userEmail = email;
            _displayName = displayName;

            _logger.LogInformation("Auth tokens stored successfully for user: {Email}", email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to store auth tokens");
            throw;
        }
    }

    public async Task ClearTokensAsync()
    {
        try
        {
            await _storage.ClearAsync(JwtTokenKey, CancellationToken.None);
            await _storage.ClearAsync(RefreshTokenKey, CancellationToken.None);
            await _storage.ClearAsync(UserEmailKey, CancellationToken.None);
            await _storage.ClearAsync(DisplayNameKey, CancellationToken.None);

            _currentToken = null;
            _userEmail = null;
            _displayName = null;

            _logger.LogInformation("Auth tokens cleared");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to clear auth tokens");
            throw;
        }
    }

    public async Task<string?> GetRefreshTokenAsync()
    {
        try
        {
            return await _storage.GetStringAsync(RefreshTokenKey, CancellationToken.None);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve refresh token");
            return null;
        }
    }
}
