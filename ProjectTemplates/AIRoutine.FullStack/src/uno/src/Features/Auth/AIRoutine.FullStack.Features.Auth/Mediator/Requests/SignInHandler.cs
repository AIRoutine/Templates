using AIRoutine.FullStack.Api.Generated;
using AIRoutine.FullStack.Features.Auth.Contracts.Mediator.Requests;
using AIRoutine.FullStack.Features.Auth.Services;
using Microsoft.Extensions.Logging;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Features.Auth.Mediator.Requests;

/// <summary>
/// Handler for <see cref="SignInRequest"/>.
/// Uses generated HTTP contracts from OpenAPI for API communication.
/// </summary>
public sealed class SignInHandler(
    IMediator mediator,
    IAuthService authService,
    ILogger<SignInHandler> logger
) : IRequestHandler<SignInRequest, SignInResponse>
{
    public async Task<SignInResponse> Handle(SignInRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing sign-in request with scheme: {Scheme}", request.Scheme);

        // Use generated HTTP contract from OpenAPI
        var httpRequest = new SignInHttpRequest { Scheme = request.Scheme };
        var response = await mediator.Request(httpRequest, cancellationToken);

        if (!response.Success || string.IsNullOrEmpty(response.Uri))
        {
            logger.LogWarning("Sign-in failed");
            return SignInResponse.Fail("Sign-in failed");
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
            return SignInResponse.Fail("Invalid sign-in response");
        }

        await authService.SetTokensAsync(jwt, refreshToken, string.Empty, null);

        logger.LogInformation("Sign-in successful");
        return SignInResponse.Successful();
    }
}
