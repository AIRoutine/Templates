using AIRoutine.FullStack.Api.Generated;
using AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Features.Auth.Contracts.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Mediator.Requests;

/// <summary>
/// Handler for <see cref="RefreshRequest"/>.
/// Uses generated HTTP contracts from OpenAPI for API communication.
/// </summary>
public sealed class RefreshHandler(
    IMediator mediator,
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

        // Use generated HTTP contract from OpenAPI
        var httpRequest = new RefreshAuthHttpRequest { Token = refreshToken };
        var response = await mediator.Request(httpRequest, cancellationToken);

        if (!response.Success || string.IsNullOrEmpty(response.Jwt) || string.IsNullOrEmpty(response.RefreshToken))
        {
            logger.LogWarning("Token refresh failed");
            await authService.ClearTokensAsync();
            return RefreshResponse.Fail("Token refresh failed");
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
