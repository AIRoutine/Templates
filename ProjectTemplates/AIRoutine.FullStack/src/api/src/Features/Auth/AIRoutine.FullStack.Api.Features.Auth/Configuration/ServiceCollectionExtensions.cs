using AIRoutine.FullStack.Api.Core.Data;
using AIRoutine.FullStack.Api.Features.Auth.Data.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Shiny.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Features.Auth.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthFeature(this IServiceCollection services)
    {
        // Register entity configurations
        AppDbContext.RegisterConfigurations(typeof(UserConfiguration).Assembly);

        services.AddShinyServiceRegistry();
        services.AddHttpContextAccessor();

        return services;
    }
}
