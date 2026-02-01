using UnoFramework.Controls;

namespace AIRoutine.FullStack.Core.Styles;

/// <summary>
/// Extension methods for applying responsive layout presets to AutoLayout.
/// </summary>
public static class ResponsiveLayoutExtensions
{
    /// <summary>
    /// Applies a responsive layout preset to the AutoLayout.
    /// </summary>
    /// <param name="autoLayout">The AutoLayout element.</param>
    /// <param name="preset">The responsive preset containing padding and spacing values.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public static AutoLayout ApplyResponsiveLayout(this AutoLayout autoLayout, ResponsivePreset preset)
    {
        return autoLayout
            .ApplyResponsivePadding(preset.Padding)
            .ApplyResponsiveSpacing(preset.Spacing);
    }

    /// <summary>
    /// Applies the default responsive layout preset.
    /// Shorthand for <c>ApplyResponsiveLayout(ResponsivePresets.Default)</c>.
    /// </summary>
    /// <param name="autoLayout">The AutoLayout element.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public static AutoLayout ApplyDefaultResponsiveLayout(this AutoLayout autoLayout) =>
        autoLayout.ApplyResponsiveLayout(ResponsivePresets.Default);

    /// <summary>
    /// Applies responsive padding values to the AutoLayout.
    /// </summary>
    /// <param name="autoLayout">The AutoLayout element.</param>
    /// <param name="values">The responsive padding values for all breakpoints.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public static AutoLayout ApplyResponsivePadding(this AutoLayout autoLayout, ResponsiveValues values)
    {
        return autoLayout.ResponsivePadding(
            narrowest: values.Narrowest,
            narrow: values.Narrow,
            normal: values.Normal,
            wide: values.Wide,
            widest: values.Widest);
    }

    /// <summary>
    /// Applies responsive spacing values to the AutoLayout.
    /// </summary>
    /// <param name="autoLayout">The AutoLayout element.</param>
    /// <param name="values">The responsive spacing values for all breakpoints.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public static AutoLayout ApplyResponsiveSpacing(this AutoLayout autoLayout, ResponsiveValues values)
    {
        return autoLayout.ResponsiveSpacing(
            narrowest: values.Narrowest,
            narrow: values.Narrow,
            normal: values.Normal,
            wide: values.Wide,
            widest: values.Widest);
    }
}
