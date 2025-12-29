using AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Features.Auth.Contracts.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Mediator.Requests;

/// <summary>
/// Handler for <see cref="GetAuthStateRequest"/>.
/// </summary>
public sealed class GetAuthStateHandler(
    IAuthService authService,
    ILogger<GetAuthStateHandler> logger
) : IRequestHandler<GetAuthStateRequest, AuthState>
{
    public Task<AuthState> Handle(GetAuthStateRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        logger.LogDebug("Getting current auth state");

        if (!authService.IsAuthenticated)
        {
            return Task.FromResult(AuthState.Anonymous);
        }

        return Task.FromResult(AuthState.Authenticated(
            authService.UserEmail ?? string.Empty,
            authService.DisplayName));
    }
}
