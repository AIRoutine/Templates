using AIRoutine.FullStack.Api.Core.Data.Configuration;
using AIRoutine.FullStack.Api.Core.Data.Seeding;
using AIRoutine.FullStack.Api.Core.Data.Seeding.Configuration;
using Microsoft.Extensions.Configuration;

namespace AIRoutine.FullStack.Api.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Data (must be before features to register DbContext first)
        services.AddAppData(configuration);
        services.AddDataSeeding();

        services.AddShinyServiceRegistry();

        // Features

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        return app;
    }

    public static async Task RunSeedersAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var seederRunner = scope.ServiceProvider.GetRequiredService<SeederRunner>();
        await seederRunner.RunAllSeedersAsync();
    }
}