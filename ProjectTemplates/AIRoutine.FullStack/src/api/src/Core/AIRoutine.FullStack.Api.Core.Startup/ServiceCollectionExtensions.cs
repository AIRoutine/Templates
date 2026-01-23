using AIRoutine.FullStack.Api.Core.Data.Configuration;
using AIRoutine.FullStack.Api.Core.Data.Seeding;
using AIRoutine.FullStack.Api.Core.Data.Seeding.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AIRoutine.FullStack.Api.Core.Startup;

/// <summary>
/// Extension methods for configuring API services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all API services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddAppData(configuration);
        _ = services.AddDataSeeding();
        _ = services.AddShinyServiceRegistry();
        _ = services.AddShinyMediator();

        return services;
    }

    /// <summary>
    /// Maps all API endpoints.
    /// </summary>
    /// <param name="app">The web application.</param>
    /// <returns>The web application for chaining.</returns>
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/health", () => Results.Ok(new HealthResponse("Healthy", DateTime.UtcNow)))
            .WithName("GetHealth")
            .WithTags("Health");

        return app;
    }

    /// <summary>
    /// Runs all registered seeders asynchronously.
    /// </summary>
    /// <param name="app">The web application.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task RunSeedersAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var seederRunner = scope.ServiceProvider.GetRequiredService<SeederRunner>();
        await seederRunner.RunAllSeedersAsync();
    }
}

/// <summary>
/// Response model for health check endpoint.
/// </summary>
/// <param name="Status">The health status.</param>
/// <param name="Timestamp">The timestamp of the check.</param>
public record HealthResponse(string Status, DateTime Timestamp);
