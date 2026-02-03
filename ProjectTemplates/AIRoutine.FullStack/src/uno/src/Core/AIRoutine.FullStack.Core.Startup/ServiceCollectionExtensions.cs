using UnoFramework.Configuration;
using UnoFramework.Mediator;

namespace AIRoutine.FullStack.Core.Startup;

/// <summary>
/// Extension methods for configuring application services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all application services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        _ = services.AddUnoFramework();
        _ = services.AddShinyServiceRegistry();
        _ = services.AddShinyMediator(cfg => cfg.AddEventCollector<UnoEventCollector>());

        return services;
    }
}
