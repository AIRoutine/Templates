namespace AIRoutine.FullStack.Core.Styles;

/// <summary>
/// Represents responsive values for the 5 screen size breakpoints.
/// </summary>
/// <param name="Narrowest">Value for narrowest screens (0-149px).</param>
/// <param name="Narrow">Value for narrow screens (150-599px).</param>
/// <param name="Normal">Value for normal screens (600-799px).</param>
/// <param name="Wide">Value for wide screens (800-1079px).</param>
/// <param name="Widest">Value for widest screens (1080px+).</param>
public readonly record struct ResponsiveValues(
    double Narrowest,
    double Narrow,
    double Normal,
    double Wide,
    double Widest);

/// <summary>
/// Defines a complete responsive layout preset with padding and spacing values.
/// </summary>
/// <param name="Padding">Responsive padding values for all breakpoints.</param>
/// <param name="Spacing">Responsive spacing values for all breakpoints.</param>
public readonly record struct ResponsivePreset(
    ResponsiveValues Padding,
    ResponsiveValues Spacing);

/// <summary>
/// Predefined responsive layout presets for common use cases.
/// </summary>
public static class ResponsivePresets
{
    /// <summary>
    /// Default responsive layout with balanced padding and spacing.
    /// </summary>
    public static ResponsivePreset Default => new(
        Padding: new(16, 20, 24, 32, 48),
        Spacing: new(12, 14, 16, 20, 24));

    /// <summary>
    /// Compact layout with reduced padding and spacing for dense content.
    /// </summary>
    public static ResponsivePreset Compact => new(
        Padding: new(8, 12, 16, 20, 24),
        Spacing: new(6, 8, 10, 12, 14));

    /// <summary>
    /// Spacious layout with increased padding and spacing for breathing room.
    /// </summary>
    public static ResponsivePreset Spacious => new(
        Padding: new(24, 32, 40, 56, 72),
        Spacing: new(16, 20, 24, 32, 40));

    /// <summary>
    /// Card layout optimized for content cards and panels.
    /// </summary>
    public static ResponsivePreset Card => new(
        Padding: new(12, 14, 16, 20, 24),
        Spacing: new(8, 10, 12, 14, 16));

    /// <summary>
    /// Form layout optimized for input forms.
    /// </summary>
    public static ResponsivePreset Form => new(
        Padding: new(16, 20, 24, 28, 32),
        Spacing: new(12, 14, 16, 18, 20));
}
