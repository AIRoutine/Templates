using System.Security.Claims;
using AIRoutine.FullStack.Shared;
using Microsoft.AspNetCore.Http;
using Shiny.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Features.Auth.Services;

[Service(AppService.Lifetime, TryAdd = AppService.TryAdd)]
public class UserService(IHttpContextAccessor accessor) : IUserService
{
    public Guid UserId =>
        Guid.Parse(accessor.HttpContext!.User!.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
