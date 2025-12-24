using AIRoutine.FullStack.Api.Features.Auth.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Core.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddShinyMediator();
        services.AddAuthFeature(configuration);

        return services;
    }
}
