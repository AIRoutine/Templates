using Uno.Toolkit.UI;
using UnoFramework.Controls;

namespace AIRoutine.FullStack.Core.Styles;

/// <summary>
/// Extension methods for applying responsive layout presets to AutoLayout.
/// </summary>
public implicit extension ResponsiveLayoutExtensions for AutoLayout
{
    /// <summary>
    /// Applies a responsive layout preset to the AutoLayout.
    /// </summary>
    /// <param name="preset">The responsive preset containing padding and spacing values.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public AutoLayout ApplyResponsiveLayout(ResponsivePreset preset)
    {
        return this
            .ApplyResponsivePadding(preset.Padding)
            .ApplyResponsiveSpacing(preset.Spacing);
    }

    /// <summary>
    /// Applies the default responsive layout preset.
    /// Shorthand for <c>ApplyResponsiveLayout(ResponsivePresets.Default)</c>.
    /// </summary>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public AutoLayout ApplyDefaultResponsiveLayout()
    {
        return this.ApplyResponsiveLayout(ResponsivePresets.Default);
    }

    /// <summary>
    /// Applies responsive padding values to the AutoLayout.
    /// </summary>
    /// <param name="values">The responsive padding values for all breakpoints.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public AutoLayout ApplyResponsivePadding(ResponsiveValues values)
    {
        return this.ResponsivePadding(
            narrowest: values.Narrowest,
            narrow: values.Narrow,
            normal: values.Normal,
            wide: values.Wide,
            widest: values.Widest);
    }

    /// <summary>
    /// Applies responsive spacing values to the AutoLayout.
    /// </summary>
    /// <param name="values">The responsive spacing values for all breakpoints.</param>
    /// <returns>The AutoLayout element for fluent chaining.</returns>
    public AutoLayout ApplyResponsiveSpacing(ResponsiveValues values)
    {
        return this.ResponsiveSpacing(
            narrowest: values.Narrowest,
            narrow: values.Narrow,
            normal: values.Normal,
            wide: values.Wide,
            widest: values.Widest);
    }
}
