using AIRoutine.FullStack.Core.ApiClient.Generated;
using AIRoutine.FullStack.Features.Auth.Contracts.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Middleware;

/// <summary>
/// Middleware that processes refresh responses and updates stored tokens.
/// </summary>
[Service(UnoService.Lifetime, TryAdd = UnoService.TryAdd)]
public sealed class RefreshMiddleware(
    IAuthService authService,
    ILogger<RefreshMiddleware> logger
) : IRequestMiddleware<RefreshAuthHttpRequest, RefreshResponse>
{
    public async Task<RefreshResponse> Process(
        IMediatorContext context,
        RequestHandlerDelegate<RefreshResponse> next,
        CancellationToken cancellationToken)
    {
        var response = await next();

        if (!response.Success || string.IsNullOrEmpty(response.Jwt) || string.IsNullOrEmpty(response.RefreshToken))
        {
            logger.LogWarning("Token refresh failed");
            await authService.ClearTokensAsync();
            return response;
        }

        await authService.SetTokensAsync(
            response.Jwt,
            response.RefreshToken,
            authService.UserEmail ?? string.Empty,
            authService.DisplayName);

        logger.LogInformation("Token refresh successful, tokens updated");
        return response;
    }
}
