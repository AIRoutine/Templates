using AIRoutine.FullStack.Api.Core.Data.Configuration;
using AIRoutine.FullStack.Api.Core.Data.Seeding;
using AIRoutine.FullStack.Api.Core.Data.Seeding.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AIRoutine.FullStack.Api.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppData(configuration);
        services.AddDataSeeding();
        services.AddShinyServiceRegistry();
        services.AddShinyMediator();

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGet("/health", () => Results.Ok(new HealthResponse("Healthy", DateTime.UtcNow)))
            .WithName("GetHealth")
            .WithTags("Health");

        return app;
    }

    public static async Task RunSeedersAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var seederRunner = scope.ServiceProvider.GetRequiredService<SeederRunner>();
        await seederRunner.RunAllSeedersAsync();
    }
}

public record HealthResponse(string Status, DateTime Timestamp);