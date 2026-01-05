using AIRoutine.FullStack.Cli.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shiny.Extensions.DependencyInjection;
using Shiny.Mediator;

namespace AIRoutine.FullStack.Cli.Configuration;

/// <summary>
/// DI-Setup fuer die CLI-Services.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCliServices(this IServiceCollection services)
    {
        // Auto-registriert alle [Service] Attribute (inkl. ProcessRunner -> IProcessRunner)
        services.AddShinyServiceRegistry();

        // Mediator registrieren
        services.AddShinyMediator();

        return services;
    }
}
