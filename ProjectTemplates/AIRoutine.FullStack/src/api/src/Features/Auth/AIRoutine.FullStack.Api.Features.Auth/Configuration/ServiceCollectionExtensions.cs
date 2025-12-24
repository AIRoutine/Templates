using AIRoutine.FullStack.Api.Features.Auth.Data;
using AIRoutine.FullStack.Api.Features.Auth.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Features.Auth.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthFeature(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<AuthDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("AuthDb") ?? "Data Source=auth.db"));

        // Services
        services.AddScoped<JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddHttpContextAccessor();

        return services;
    }
}
