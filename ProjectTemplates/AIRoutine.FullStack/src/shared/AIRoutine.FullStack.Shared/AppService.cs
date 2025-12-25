using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Shared;

/// <summary>
/// Plattform-spezifische DI-Konstanten.
/// </summary>
public static class AppService
{
    /// <summary>
    /// Immer TryAdd verwenden.
    /// </summary>
    public const bool TryAdd = true;

#if API
    /// <summary>
    /// Default: Scoped für API (pro Request).
    /// </summary>
    public const ServiceLifetime Lifetime = ServiceLifetime.Scoped;
#elif UNO
    /// <summary>
    /// Default: Singleton für Uno/Client-Apps.
    /// </summary>
    public const ServiceLifetime Lifetime = ServiceLifetime.Singleton;
#else
    /// <summary>
    /// Fallback: Singleton.
    /// </summary>
    public const ServiceLifetime Lifetime = ServiceLifetime.Singleton;
#endif
}
