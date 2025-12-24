namespace AIRoutine.FullStack.Api.Features.Auth.Data;

public class RefreshToken
{
    public string Id { get; set; } = string.Empty;
    public DateTimeOffset DateCreated { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
