using AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Features.Auth.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Mediator.Requests;

/// <summary>
/// Handler for <see cref="SignOutCommand"/>.
/// </summary>
public sealed class SignOutHandler(
    IAuthApiClient apiClient,
    IAuthService authService,
    ILogger<SignOutHandler> logger
) : ICommandHandler<SignOutCommand>
{
    public async Task Handle(SignOutCommand command, IMediatorContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing sign-out request");

        var refreshToken = await authService.GetRefreshTokenAsync();
        if (!string.IsNullOrEmpty(refreshToken))
        {
            await apiClient.SignOutAsync(refreshToken, null, cancellationToken);
        }

        await authService.ClearTokensAsync();

        logger.LogInformation("Sign-out completed");
    }
}
