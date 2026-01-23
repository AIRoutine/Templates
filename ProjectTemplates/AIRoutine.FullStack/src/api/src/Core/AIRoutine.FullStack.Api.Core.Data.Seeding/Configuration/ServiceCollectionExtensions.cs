using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Core.Data.Seeding.Configuration;

/// <summary>
/// Extension methods for configuring seeding services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the seeding infrastructure. Call this in Core.Startup.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddDataSeeding(this IServiceCollection services)
    {
        _ = services.AddSingleton<SeederRunner>();
        return services;
    }

    /// <summary>
    /// Registers a seeder. Call this in each feature's ServiceCollectionExtensions.
    /// </summary>
    /// <typeparam name="TSeeder">The seeder type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddSeeder<TSeeder>(this IServiceCollection services)
        where TSeeder : class, ISeeder
    {
        _ = services.AddScoped<ISeeder, TSeeder>();
        return services;
    }
}
