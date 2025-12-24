using AIRoutine.FullStack.Api.Core.Data;
using AIRoutine.FullStack.Api.Features.Auth.Data.Configurations;
using AIRoutine.FullStack.Api.Features.Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Features.Auth.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthFeature(this IServiceCollection services)
    {
        // Register entity configurations
        AppDbContext.RegisterConfigurations(typeof(UserConfiguration).Assembly);

        // Services
        services.AddScoped<JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddHttpContextAccessor();

        return services;
    }
}
