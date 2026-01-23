using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AIRoutine.FullStack.Api.Core.Data.Seeding;

/// <summary>
/// Runs all registered seeders in order.
/// </summary>
/// <param name="serviceProvider">The service provider.</param>
/// <param name="logger">The logger.</param>
public class SeederRunner(IServiceProvider serviceProvider, ILogger<SeederRunner> logger)
{
    /// <summary>
    /// Runs all registered seeders asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RunAllSeedersAsync(CancellationToken cancellationToken = default)
    {
        using var scope = serviceProvider.CreateScope();
        var seeders = scope.ServiceProvider.GetServices<ISeeder>()
            .OrderBy(s => s.Order)
            .ToList();

        if (seeders.Count == 0)
        {
            logger.LogInformation("No seeders registered");
            return;
        }

        logger.LogInformation("Running {Count} seeders", seeders.Count);

        foreach (var seeder in seeders)
        {
            var seederName = seeder.GetType().Name;
            logger.LogInformation("Running seeder: {SeederName}", seederName);

            try
            {
                await seeder.SeedAsync(cancellationToken);
                logger.LogInformation("Seeder {SeederName} completed", seederName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Seeder {SeederName} failed", seederName);
                throw;
            }
        }

        logger.LogInformation("All seeders completed");
    }
}
