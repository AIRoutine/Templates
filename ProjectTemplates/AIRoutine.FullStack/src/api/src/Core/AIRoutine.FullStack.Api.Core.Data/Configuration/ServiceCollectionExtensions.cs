using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Core.Data.Configuration;

/// <summary>
/// Extension methods for configuring data services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the application data context to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddAppData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=app.db";

        _ = services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        return services;
    }

    /// <summary>
    /// Ensures the database is created.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        _ = dbContext.Database.EnsureCreated();
    }
}
