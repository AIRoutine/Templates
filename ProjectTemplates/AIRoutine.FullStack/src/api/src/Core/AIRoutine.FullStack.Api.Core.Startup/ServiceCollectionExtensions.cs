using AIRoutine.FullStack.Api.Core.Data.Configuration;
using AIRoutine.FullStack.Api.Features.Auth.Configuration;
using Microsoft.Extensions.Configuration;

namespace AIRoutine.FullStack.Api.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Data (must be before features to register DbContext first)
        services.AddAppData(configuration);

        services.AddShinyServiceRegistry();

        // Features
        services.AddAuthFeature();

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        return app.MapAuthEndpoints();
    }
}