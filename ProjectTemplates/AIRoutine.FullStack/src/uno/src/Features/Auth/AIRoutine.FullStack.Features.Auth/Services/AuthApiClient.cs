using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace AIRoutine.FullStack.Features.Auth.Services;

/// <summary>
/// Implementation of <see cref="IAuthApiClient"/> using HttpClient.
/// </summary>
public sealed class AuthApiClient : IAuthApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthApiClient> _logger;

    public AuthApiClient(HttpClient httpClient, ILogger<AuthApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<ApiSignInResponse> SignInAsync(string scheme, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new SignInApiRequest(scheme);
            var response = await _httpClient.PostAsJsonAsync("/auth/signin/mobile", request, AuthApiJsonContext.Default.SignInApiRequest, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync(AuthApiJsonContext.Default.SignInApiResult, cancellationToken);
                if (result?.Success == true)
                {
                    return new ApiSignInResponse(true, result.Jwt, result.RefreshToken, result.Email, result.DisplayName, null);
                }
            }

            _logger.LogWarning("Sign-in failed with status: {StatusCode}", response.StatusCode);
            return new ApiSignInResponse(false, null, null, null, null, "Sign-in failed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Sign-in request failed");
            return new ApiSignInResponse(false, null, null, null, null, ex.Message);
        }
    }

    public async Task<ApiRefreshResponse> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new RefreshApiRequest(refreshToken);
            var response = await _httpClient.PostAsJsonAsync("/auth/signin/refresh", request, AuthApiJsonContext.Default.RefreshApiRequest, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync(AuthApiJsonContext.Default.RefreshApiResult, cancellationToken);
                if (result?.Success == true)
                {
                    return new ApiRefreshResponse(true, result.Jwt, result.RefreshToken, null);
                }
            }

            _logger.LogWarning("Token refresh failed with status: {StatusCode}", response.StatusCode);
            return new ApiRefreshResponse(false, null, null, "Token refresh failed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token refresh request failed");
            return new ApiRefreshResponse(false, null, null, ex.Message);
        }
    }

    public async Task SignOutAsync(string refreshToken, string? pushToken = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new SignOutApiRequest(refreshToken, pushToken);
            var response = await _httpClient.PostAsJsonAsync("/auth/signout", request, AuthApiJsonContext.Default.SignOutApiRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Sign-out request returned status: {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Sign-out request failed");
        }
    }
}

// Request types for AOT/Trimming compatibility
internal sealed record SignInApiRequest(string Scheme);
internal sealed record RefreshApiRequest(string Token);
internal sealed record SignOutApiRequest(string RefreshToken, string? PushToken);

// Response types
internal sealed record SignInApiResult(bool Success, string? Jwt, string? RefreshToken, string? Email, string? DisplayName);
internal sealed record RefreshApiResult(bool Success, string? Jwt, string? RefreshToken);

/// <summary>
/// JSON serializer context for AOT/Trimming compatibility.
/// </summary>
[JsonSerializable(typeof(SignInApiRequest))]
[JsonSerializable(typeof(RefreshApiRequest))]
[JsonSerializable(typeof(SignOutApiRequest))]
[JsonSerializable(typeof(SignInApiResult))]
[JsonSerializable(typeof(RefreshApiResult))]
internal sealed partial class AuthApiJsonContext : JsonSerializerContext;
