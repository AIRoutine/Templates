using AIRoutine.FullStack.Api.Core.Data.Entities;

namespace AIRoutine.FullStack.Api.Features.Auth.Data.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
