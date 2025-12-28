using AIRoutine.FullStack.Features.Auth.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shiny.Mediator.Infrastructure;
using UnoFramework.Mediator;
using UnoFramework.ViewModels;

namespace AIRoutine.FullStack.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        // Auto-register services with [Service] attribute
        services.AddShinyServiceRegistry();

        services.AddShinyMediator();
        services.AddSingleton<IEventCollector, UnoEventCollector>();
        services.AddSingleton<BaseServices>();

        // Features
        services.AddAuthFeature();

        return services;
    }
}
