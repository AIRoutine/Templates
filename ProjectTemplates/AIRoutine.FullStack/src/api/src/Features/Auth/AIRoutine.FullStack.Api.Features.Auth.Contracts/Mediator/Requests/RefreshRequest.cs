namespace AIRoutine.FullStack.Api.Features.Auth.Contracts.Mediator.Requests;

public record RefreshRequest(string Token) : IRequest<RefreshResponse>;

public record RefreshResponse(bool Success, string? Jwt, string? RefreshToken)
{
    public static readonly RefreshResponse Fail = new(false, null, null);
    public static RefreshResponse Successful(string jwt, string refresh) => new(true, jwt, refresh);
}
