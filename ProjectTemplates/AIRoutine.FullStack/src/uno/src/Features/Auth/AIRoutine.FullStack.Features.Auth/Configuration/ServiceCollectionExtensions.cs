using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Features.Auth.Configuration;

/// <summary>
/// Extension methods for registering Auth feature services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Auth feature services to the service collection.
    /// </summary>
    /// <remarks>
    /// Services with [Service] attribute are auto-registered via AddShinyServiceRegistry().
    /// API communication uses generated HTTP contracts from OpenAPI (Shiny.Mediator.Http).
    /// </remarks>
    public static IServiceCollection AddAuthFeature(this IServiceCollection services)
    {
        // No explicit HttpClient registration needed -
        // Shiny.Mediator.Http handles API calls via generated contracts
        return services;
    }
}
