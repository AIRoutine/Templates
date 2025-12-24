using Microsoft.Extensions.DependencyInjection;
using Shiny.Mediator.Infrastructure;

namespace AIRoutine.FullStack.Core.Startup;

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
