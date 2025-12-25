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
    public static IServiceCollection AddAuthFeature(this IServiceCollection services)
    {
        // Services
        services.AddSingleton<IAuthService, AuthService>();

        // API Client
        services.AddHttpClient<IAuthApiClient, AuthApiClient>();

        return services;
    }

    /// <summary>
    /// Adds the Auth feature services with a configured base address for the API.
    /// </summary>
    public static IServiceCollection AddAuthFeature(this IServiceCollection services, string apiBaseAddress)
    {
        // Services
        services.AddSingleton<IAuthService, AuthService>();

        // API Client with configured base address
        services.AddHttpClient<IAuthApiClient, AuthApiClient>(client =>
        {
            client.BaseAddress = new Uri(apiBaseAddress);
        });

        return services;
    }
}
