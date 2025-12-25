using Microsoft.Extensions.DependencyInjection;

namespace AIRoutine.FullStack.Shared;

/// <summary>
/// Plattform-spezifische ServiceLifetime-Konstanten.
/// </summary>
public static class AppLifetime
{
#if API
    /// <summary>
    /// Default: Scoped für API (pro Request).
    /// </summary>
    public const ServiceLifetime Default = ServiceLifetime.Scoped;
#elif UNO
    /// <summary>
    /// Default: Singleton für Uno/Client-Apps.
    /// </summary>
    public const ServiceLifetime Default = ServiceLifetime.Singleton;
#else
    /// <summary>
    /// Fallback: Singleton.
    /// </summary>
    public const ServiceLifetime Default = ServiceLifetime.Singleton;
#endif

    public const ServiceLifetime Singleton = ServiceLifetime.Singleton;
    public const ServiceLifetime Transient = ServiceLifetime.Transient;
    public const ServiceLifetime Scoped = ServiceLifetime.Scoped;
}
