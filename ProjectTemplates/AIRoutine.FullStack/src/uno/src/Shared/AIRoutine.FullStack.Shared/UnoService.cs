using UnoFramework;

namespace AIRoutine.FullStack.Shared;

/// <summary>
/// Uno-spezifische DI-Konstanten. Delegiert zu <see cref="UnoFrameworkService"/>.
/// </summary>
public static class UnoService
{
    /// <inheritdoc cref="UnoFrameworkService.Lifetime"/>
    public const ServiceLifetime Lifetime = UnoFrameworkService.Lifetime;

    /// <inheritdoc cref="UnoFrameworkService.PageLifetime"/>
    public const ServiceLifetime PageLifetime = UnoFrameworkService.PageLifetime;

    /// <inheritdoc cref="UnoFrameworkService.TryAdd"/>
    public const bool TryAdd = UnoFrameworkService.TryAdd;
}
