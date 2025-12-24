using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Api.Core.Data.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppData(this IServiceCollection services, IConfiguration configuration)
    {
        var provider = configuration.GetValue<string>("Database:Provider") ?? "sqlite";
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=app.db";

        services.AddDbContext<AppDbContext>(options =>
        {
            _ = provider.ToLowerInvariant() switch
            {
                "sqlite" => options.UseSqlite(connectionString),
                "postgresql" or "postgres" => options.UseNpgsql(connectionString),
                "sqlserver" or "mssql" => options.UseSqlServer(connectionString),
                _ => throw new ArgumentException($"Unsupported database provider: {provider}")
            };
        });

        return services;
    }
}
