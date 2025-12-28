using AIRoutine.FullStack.Features.Auth.Services;
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
    /// </remarks>
    public static IServiceCollection AddAuthFeature(this IServiceCollection services)
    {
        // API Client (HttpClient requires explicit registration)
        services.AddHttpClient<IAuthApiClient, AuthApiClient>();

        return services;
    }

    /// <summary>
    /// Adds the Auth feature services with a configured base address for the API.
    /// </summary>
    /// <remarks>
    /// Services with [Service] attribute are auto-registered via AddShinyServiceRegistry().
    /// </remarks>
    public static IServiceCollection AddAuthFeature(this IServiceCollection services, string apiBaseAddress)
    {
        // API Client with configured base address
        services.AddHttpClient<IAuthApiClient, AuthApiClient>(client =>
        {
            client.BaseAddress = new Uri(apiBaseAddress);
        });

        return services;
    }
}
