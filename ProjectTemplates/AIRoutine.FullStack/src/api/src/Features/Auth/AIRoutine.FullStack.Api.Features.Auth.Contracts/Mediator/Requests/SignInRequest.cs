namespace AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;

public record SignInRequest(string Scheme) : IRequest<SignInResponse>;

public record SignInResponse(bool Success, string? Uri = null)
{
    public static SignInResponse Fail { get; } = new(false);
    public static SignInResponse Successful(string uri) => new(true, uri);
}
