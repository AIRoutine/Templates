using AIRoutine.FullStack.Core.ApiClient.Generated;
using AIRoutine.FullStack.Features.Auth.Contracts.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Middleware;

/// <summary>
/// Middleware that processes sign-in responses and stores tokens.
/// </summary>
[Service(UnoService.Lifetime, TryAdd = UnoService.TryAdd)]
public sealed class SignInMiddleware(
    IAuthService authService,
    ILogger<SignInMiddleware> logger
) : IRequestMiddleware<SignInHttpRequest, SignInResponse>
{
    public async Task<SignInResponse> Process(
        IMediatorContext context,
        RequestHandlerDelegate<SignInResponse> next,
        CancellationToken cancellationToken)
    {
        var response = await next();

        if (!response.Success || string.IsNullOrEmpty(response.Uri))
        {
            logger.LogWarning("Sign-in failed or no URI returned");
            return response;
        }

        // Parse tokens from callback URI (format: myapp://#newuser=...&access_token=...&refresh_token=...)
        var uri = new Uri(response.Uri);
        var fragment = uri.Fragment.TrimStart('#');
        var parameters = fragment.Split('&')
            .Select(p => p.Split('='))
            .Where(p => p.Length == 2)
            .ToDictionary(p => p[0], p => Uri.UnescapeDataString(p[1]));

        if (!parameters.TryGetValue("access_token", out var jwt) ||
            !parameters.TryGetValue("refresh_token", out var refreshToken))
        {
            logger.LogWarning("Sign-in response missing tokens");
            return response;
        }

        await authService.SetTokensAsync(jwt, refreshToken, string.Empty, null);
        logger.LogInformation("Sign-in successful, tokens stored");

        return response;
    }
}
