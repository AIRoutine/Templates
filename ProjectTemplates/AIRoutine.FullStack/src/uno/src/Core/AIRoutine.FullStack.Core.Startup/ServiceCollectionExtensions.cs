using Shiny.Mediator.Infrastructure;
using UnoFramework.Mediator;

namespace AIRoutine.FullStack.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddShinyServiceRegistry();
        services.AddShinyMediator();
        services.AddSingleton<IEventCollector, UnoEventCollector>();

        return services;
    }
}
