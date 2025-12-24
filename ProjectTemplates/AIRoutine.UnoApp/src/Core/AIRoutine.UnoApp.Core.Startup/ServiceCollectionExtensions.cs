using Microsoft.Extensions.DependencyInjection;
using Shiny.Mediator.Infrastructure;

namespace AIRoutine.UnoApp.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddShinyMediator();
        services.AddSingleton<IEventCollector, UnoEventCollector>();
        services.AddSingleton<BaseServices>();

        return services;
    }
}
