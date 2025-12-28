using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Shiny.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Features.Auth.Services;

[Service(ApiService.Lifetime, TryAdd = ApiService.TryAdd)]
public class UserService(IHttpContextAccessor accessor) : IUserService
{
    public Guid UserId =>
        Guid.Parse(accessor.HttpContext!.User!.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
