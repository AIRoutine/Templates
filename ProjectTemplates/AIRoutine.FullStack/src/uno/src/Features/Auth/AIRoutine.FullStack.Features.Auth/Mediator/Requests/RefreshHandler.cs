using AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Features.Auth.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Mediator.Requests;

/// <summary>
/// Handler for <see cref="RefreshRequest"/>.
/// </summary>
public sealed class RefreshHandler(
    IAuthApiClient apiClient,
    IAuthService authService,
    ILogger<RefreshHandler> logger
) : IRequestHandler<RefreshRequest, RefreshResponse>
{
    public async Task<RefreshResponse> Handle(RefreshRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing token refresh request");

        var refreshToken = await authService.GetRefreshTokenAsync();
        if (string.IsNullOrEmpty(refreshToken))
        {
            logger.LogWarning("No refresh token available");
            return RefreshResponse.Fail("No refresh token available");
        }

        var response = await apiClient.RefreshAsync(refreshToken, cancellationToken);

        if (!response.Success || string.IsNullOrEmpty(response.Jwt) || string.IsNullOrEmpty(response.RefreshToken))
        {
            logger.LogWarning("Token refresh failed: {ErrorMessage}", response.ErrorMessage);
            await authService.ClearTokensAsync();
            return RefreshResponse.Fail(response.ErrorMessage ?? "Token refresh failed");
        }

        await authService.SetTokensAsync(
            response.Jwt,
            response.RefreshToken,
            authService.UserEmail ?? string.Empty,
            authService.DisplayName);

        logger.LogInformation("Token refresh successful");
        return RefreshResponse.Successful();
    }
}
