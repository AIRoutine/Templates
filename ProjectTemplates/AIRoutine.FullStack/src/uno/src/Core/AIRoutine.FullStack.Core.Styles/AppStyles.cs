using Windows.UI;

namespace AIRoutine.FullStack.Core.Styles;

/// <summary>
/// Factory for creating application-wide style resources.
/// </summary>
public static class AppStyles
{
    /// <summary>
    /// Creates the application's resource dictionary with theme overrides, tokens, and responsive styles.
    /// </summary>
    /// <returns>A configured <see cref="ResourceDictionary"/> with all application styles.</returns>
    public static ResourceDictionary Create()
    {
        var root = new ResourceDictionary();

        AddThemeOverrides(root);
        AddTokens(root);
        AddResponsiveStyles(root);

        return root;
    }

    private static void AddThemeOverrides(ResourceDictionary root)
    {
        var light = new ResourceDictionary();
        AddLightThemeResources(light);

        var dark = new ResourceDictionary();
        AddDarkThemeResources(dark);

        var highContrast = new ResourceDictionary();
        AddHighContrastResources(highContrast);

        root.ThemeDictionaries["Light"] = light;
        root.ThemeDictionaries["Dark"] = dark;
        root.ThemeDictionaries["HighContrast"] = highContrast;
    }

    private static void AddLightThemeResources(ResourceDictionary resources)
    {
        resources["SystemAccentColor"] = Rgb(0, 95, 184);
        resources["SystemAccentColorLight1"] = Rgb(26, 109, 192);
        resources["SystemAccentColorLight2"] = Rgb(51, 128, 200);
        resources["SystemAccentColorLight3"] = Rgb(77, 147, 208);
        resources["SystemAccentColorDark1"] = Rgb(0, 76, 153);
        resources["SystemAccentColorDark2"] = Rgb(0, 61, 122);
        resources["SystemAccentColorDark3"] = Rgb(0, 46, 92);

        resources["SystemAccentColorBrush"] = Solid((Color)resources["SystemAccentColor"]);
        resources["AccentBrush"] = Solid((Color)resources["SystemAccentColor"]);

        resources["SolidBackgroundFillColorBase"] = Rgb(243, 243, 243);
        resources["SolidBackgroundFillColorSecondary"] = Rgb(238, 238, 238);
        resources["SolidBackgroundFillColorTertiary"] = Rgb(249, 249, 249);

        resources["LayerFillColorDefault"] = Rgb(255, 255, 255);
        resources["LayerFillColorAlt"] = Rgb(255, 255, 255);
        resources["CardBackgroundFillColorDefault"] = Rgb(255, 255, 255);
        resources["CardBackgroundFillColorSecondary"] = Rgb(246, 246, 246);

        resources["TextFillColorPrimary"] = Rgb(26, 26, 26);
        resources["TextFillColorSecondary"] = Rgb(92, 92, 92);
        resources["TextFillColorTertiary"] = Rgb(138, 138, 138);
        resources["TextFillColorDisabled"] = Rgb(160, 160, 160);

        resources["ControlStrokeColorDefault"] = Rgb(214, 214, 214);
        resources["ControlStrokeColorSecondary"] = Rgb(224, 224, 224);
        resources["DividerStrokeColorDefault"] = Rgb(232, 232, 232);

        resources["SystemErrorColor"] = Rgb(196, 43, 28);
        resources["SystemSuccessColor"] = Rgb(15, 123, 15);
        resources["SystemWarningColor"] = Rgb(157, 93, 0);
        resources["SystemInfoColor"] = Rgb(0, 120, 212);

        resources["ErrorBrush"] = Solid((Color)resources["SystemErrorColor"]);
        resources["SuccessBrush"] = Solid((Color)resources["SystemSuccessColor"]);
        resources["WarningBrush"] = Solid((Color)resources["SystemWarningColor"]);
        resources["InfoBrush"] = Solid((Color)resources["SystemInfoColor"]);

        resources["BackgroundBrush"] = Solid((Color)resources["SolidBackgroundFillColorBase"]);
        resources["SurfaceBrush"] = Solid((Color)resources["LayerFillColorDefault"]);
        resources["CardBrush"] = Solid((Color)resources["CardBackgroundFillColorDefault"]);
        resources["OnBackgroundBrush"] = Solid((Color)resources["TextFillColorPrimary"]);
        resources["OnSurfaceBrush"] = Solid((Color)resources["TextFillColorPrimary"]);
        resources["OnSurfaceVariantBrush"] = Solid((Color)resources["TextFillColorSecondary"]);
        resources["BorderBrush"] = Solid((Color)resources["ControlStrokeColorDefault"]);
        resources["DividerBrush"] = Solid((Color)resources["DividerStrokeColorDefault"]);
    }

    private static void AddDarkThemeResources(ResourceDictionary resources)
    {
        resources["SystemAccentColor"] = Rgb(96, 205, 255);
        resources["SystemAccentColorLight1"] = Rgb(122, 213, 255);
        resources["SystemAccentColorLight2"] = Rgb(147, 221, 255);
        resources["SystemAccentColorLight3"] = Rgb(173, 229, 255);
        resources["SystemAccentColorDark1"] = Rgb(77, 196, 247);
        resources["SystemAccentColorDark2"] = Rgb(58, 187, 239);
        resources["SystemAccentColorDark3"] = Rgb(39, 178, 231);

        resources["SystemAccentColorBrush"] = Solid((Color)resources["SystemAccentColor"]);
        resources["AccentBrush"] = Solid((Color)resources["SystemAccentColor"]);

        resources["SolidBackgroundFillColorBase"] = Rgb(32, 32, 32);
        resources["SolidBackgroundFillColorSecondary"] = Rgb(28, 28, 28);
        resources["SolidBackgroundFillColorTertiary"] = Rgb(40, 40, 40);

        resources["LayerFillColorDefault"] = Rgb(45, 45, 45);
        resources["LayerFillColorAlt"] = Rgb(51, 51, 51);
        resources["CardBackgroundFillColorDefault"] = Rgb(45, 45, 45);
        resources["CardBackgroundFillColorSecondary"] = Rgb(50, 50, 50);

        resources["TextFillColorPrimary"] = Rgb(255, 255, 255);
        resources["TextFillColorSecondary"] = Rgb(197, 197, 197);
        resources["TextFillColorTertiary"] = Rgb(154, 154, 154);
        resources["TextFillColorDisabled"] = Rgb(109, 109, 109);

        resources["ControlStrokeColorDefault"] = Rgb(77, 77, 77);
        resources["ControlStrokeColorSecondary"] = Rgb(64, 64, 64);
        resources["DividerStrokeColorDefault"] = Rgb(61, 61, 61);

        resources["SystemErrorColor"] = Rgb(255, 153, 164);
        resources["SystemSuccessColor"] = Rgb(108, 203, 95);
        resources["SystemWarningColor"] = Rgb(252, 225, 0);
        resources["SystemInfoColor"] = Rgb(96, 205, 255);

        resources["ErrorBrush"] = Solid((Color)resources["SystemErrorColor"]);
        resources["SuccessBrush"] = Solid((Color)resources["SystemSuccessColor"]);
        resources["WarningBrush"] = Solid((Color)resources["SystemWarningColor"]);
        resources["InfoBrush"] = Solid((Color)resources["SystemInfoColor"]);

        resources["BackgroundBrush"] = Solid((Color)resources["SolidBackgroundFillColorBase"]);
        resources["SurfaceBrush"] = Solid((Color)resources["LayerFillColorDefault"]);
        resources["CardBrush"] = Solid((Color)resources["CardBackgroundFillColorDefault"]);
        resources["OnBackgroundBrush"] = Solid((Color)resources["TextFillColorPrimary"]);
        resources["OnSurfaceBrush"] = Solid((Color)resources["TextFillColorPrimary"]);
        resources["OnSurfaceVariantBrush"] = Solid((Color)resources["TextFillColorSecondary"]);
        resources["BorderBrush"] = Solid((Color)resources["ControlStrokeColorDefault"]);
        resources["DividerBrush"] = Solid((Color)resources["DividerStrokeColorDefault"]);
    }

    private static void AddHighContrastResources(ResourceDictionary resources)
    {
        var highlight = GetColorResource("SystemColorHighlightColor");
        var window = GetColorResource("SystemColorWindowColor");
        var text = GetColorResource("SystemColorWindowTextColor");
        var grayText = GetColorResource("SystemColorGrayTextColor");

        resources["AccentBrush"] = Solid(highlight);
        resources["BackgroundBrush"] = Solid(window);
        resources["SurfaceBrush"] = Solid(window);
        resources["CardBrush"] = Solid(window);
        resources["OnBackgroundBrush"] = Solid(text);
        resources["OnSurfaceBrush"] = Solid(text);
        resources["OnSurfaceVariantBrush"] = Solid(grayText);
        resources["BorderBrush"] = Solid(text);
        resources["DividerBrush"] = Solid(text);
        resources["ErrorBrush"] = Solid(highlight);
        resources["SuccessBrush"] = Solid(highlight);
        resources["WarningBrush"] = Solid(highlight);
        resources["InfoBrush"] = Solid(highlight);
    }

    private static void AddTokens(ResourceDictionary resources)
    {
        resources["SpacingXs"] = 4d;
        resources["SpacingSm"] = 8d;
        resources["SpacingMd"] = 16d;
        resources["SpacingLg"] = 24d;
        resources["SpacingXl"] = 32d;
        resources["SpacingXxl"] = 48d;

        resources["RadiusSm"] = new CornerRadius(4);
        resources["RadiusMd"] = new CornerRadius(8);
        resources["RadiusLg"] = new CornerRadius(12);
        resources["RadiusFull"] = new CornerRadius(9999);

        resources["BorderThin"] = new Thickness(1);
        resources["PaddingSm"] = new Thickness(8);
        resources["PaddingMd"] = new Thickness(16);
        resources["PaddingLg"] = new Thickness(24);
    }

    private static void AddResponsiveStyles(ResourceDictionary resources)
    {
        var backgroundBrush = GetBrushResource("BackgroundBrush");
        var surfaceBrush = GetBrushResource("SurfaceBrush");
        var borderBrush = GetBrushResource("BorderBrush");

        var responsivePageRootStyle = new Style(typeof(Grid));
        responsivePageRootStyle.Setters.Add(new Setter(Panel.BackgroundProperty, backgroundBrush));
        resources["ResponsivePageRootStyle"] = responsivePageRootStyle;

        var responsivePageContentStyle = new Style(typeof(Grid));
        responsivePageContentStyle.Setters.Add(new Setter(Panel.BackgroundProperty, backgroundBrush));
        responsivePageContentStyle.Setters.Add(new Setter(Grid.PaddingProperty, new Thickness(24)));
        resources["ResponsivePageContentStyle"] = responsivePageContentStyle;

        var responsiveContentStackStyle = new Style(typeof(StackPanel));
        responsiveContentStackStyle.Setters.Add(new Setter(StackPanel.SpacingProperty, 16d));
        resources["ResponsiveContentStackStyle"] = responsiveContentStackStyle;

        var responsiveSectionStackStyle = new Style(typeof(StackPanel));
        responsiveSectionStackStyle.Setters.Add(new Setter(StackPanel.SpacingProperty, 24d));
        resources["ResponsiveSectionStackStyle"] = responsiveSectionStackStyle;

        var responsiveCompactStackStyle = new Style(typeof(StackPanel));
        responsiveCompactStackStyle.Setters.Add(new Setter(StackPanel.SpacingProperty, 8d));
        resources["ResponsiveCompactStackStyle"] = responsiveCompactStackStyle;

        var responsiveCardStyle = new Style(typeof(Border));
        responsiveCardStyle.Setters.Add(new Setter(Border.BackgroundProperty, surfaceBrush));
        responsiveCardStyle.Setters.Add(new Setter(Border.BorderBrushProperty, borderBrush));
        responsiveCardStyle.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(1)));
        responsiveCardStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(8)));
        responsiveCardStyle.Setters.Add(new Setter(Border.PaddingProperty, new Thickness(16)));
        resources["ResponsiveCardStyle"] = responsiveCardStyle;

        var responsiveCardSubtleStyle = new Style(typeof(Border));
        responsiveCardSubtleStyle.Setters.Add(new Setter(Border.BackgroundProperty, surfaceBrush));
        responsiveCardSubtleStyle.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(0)));
        responsiveCardSubtleStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(8)));
        responsiveCardSubtleStyle.Setters.Add(new Setter(Border.PaddingProperty, new Thickness(16)));
        resources["ResponsiveCardSubtleStyle"] = responsiveCardSubtleStyle;

        var responsiveScrollableContentStyle = new Style(typeof(ScrollViewer));
        responsiveScrollableContentStyle.Setters.Add(new Setter(ScrollViewer.PaddingProperty, new Thickness(24)));
        resources["ResponsiveScrollableContentStyle"] = responsiveScrollableContentStyle;
    }

    private static Color Rgb(byte r, byte g, byte b) => new()
    {
        A = 255,
        R = r,
        G = g,
        B = b
    };

    private static SolidColorBrush Solid(Color color) => new(color);

    private static Color GetColorResource(string key) =>
        Application.Current?.Resources.TryGetValue(key, out var value) != true
            ? default
            : value switch
            {
                Color color => color,
                SolidColorBrush brush => brush.Color,
                _ => default
            };

    private static Brush GetBrushResource(string key) =>
        Application.Current?.Resources.TryGetValue(key, out var value) == true && value is Brush brush
            ? brush
            : new SolidColorBrush();
}
