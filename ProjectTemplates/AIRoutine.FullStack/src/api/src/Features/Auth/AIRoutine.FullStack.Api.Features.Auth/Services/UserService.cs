using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace AIRoutine.FullStack.Api.Features.Auth.Services;

public class UserService(IHttpContextAccessor accessor) : IUserService
{
    public Guid UserId =>
        Guid.Parse(accessor.HttpContext!.User!.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
