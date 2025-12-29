using System.Net.Http.Headers;
using AIRoutine.FullStack.Features.Auth.Contracts.Services;
using AIRoutine.FullStack.Http;

namespace AIRoutine.FullStack.Features.Auth.Services;

/// <summary>
/// Contributes authentication headers to outgoing HTTP requests.
/// </summary>
/// <remarks>
/// Adds Bearer token from <see cref="IAuthService"/> when the user is authenticated.
/// Priority 0 ensures authentication headers are added before other contributors.
/// </remarks>
[Service(UnoService.Lifetime, TryAdd = UnoService.TryAdd)]
public sealed class AuthHeaderContributor : IHttpHeaderContributor
{
    private readonly IAuthService _authService;

    public AuthHeaderContributor(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Authentication has highest priority (executes first).
    /// </summary>
    public int Priority => 0;

    public Task ContributeAsync(HttpRequestMessage request, CancellationToken ct = default)
    {
        if (_authService.IsAuthenticated && !string.IsNullOrEmpty(_authService.CurrentToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authService.CurrentToken);
        }

        return Task.CompletedTask;
    }
}
