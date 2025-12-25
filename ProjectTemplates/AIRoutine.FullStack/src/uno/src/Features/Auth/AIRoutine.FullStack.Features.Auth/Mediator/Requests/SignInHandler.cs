using AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Features.Auth.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Mediator.Requests;

/// <summary>
/// Handler for <see cref="SignInRequest"/>.
/// </summary>
public sealed class SignInHandler(
    IAuthApiClient apiClient,
    IAuthService authService,
    ILogger<SignInHandler> logger
) : IRequestHandler<SignInRequest, SignInResponse>
{
    public async Task<SignInResponse> Handle(SignInRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing sign-in request with scheme: {Scheme}", request.Scheme);

        var response = await apiClient.SignInAsync(request.Scheme, cancellationToken);

        if (!response.Success || string.IsNullOrEmpty(response.Jwt) || string.IsNullOrEmpty(response.RefreshToken))
        {
            logger.LogWarning("Sign-in failed: {ErrorMessage}", response.ErrorMessage);
            return SignInResponse.Fail(response.ErrorMessage ?? "Sign-in failed");
        }

        await authService.SetTokensAsync(
            response.Jwt,
            response.RefreshToken,
            response.Email ?? string.Empty,
            response.DisplayName);

        logger.LogInformation("Sign-in successful for user: {Email}", response.Email);
        return SignInResponse.Successful();
    }
}
