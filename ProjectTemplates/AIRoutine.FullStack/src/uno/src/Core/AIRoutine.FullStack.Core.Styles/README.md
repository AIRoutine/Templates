# AIRoutine.FullStack.Core.Styles

Zentrales Styling-Projekt mit Design-Tokens, Themes und Control-Styles.

## Zweck

- Design-System mit wiederverwendbaren Tokens
- Light/Dark Theme Unterstützung
- Control-Styles und Templates
- Responsive Layout-Definitionen

## Struktur

```
Core.Styles/
├── Styles.xaml                    # Haupt-ResourceDictionary (Einstiegspunkt)
├── Tokens/
│   ├── Colors.xaml               # Basis-Farbpalette
│   ├── Spacing.xaml              # Abstände (Margins, Paddings)
│   ├── Typography.xaml           # Schriftgrößen, Gewichte
│   └── Responsive.xaml           # Breakpoints
├── Themes/
│   ├── ThemeResources.xaml       # Theme-Switcher
│   ├── Colors.Light.xaml         # Light Theme Farben
│   └── Colors.Dark.xaml          # Dark Theme Farben
├── Typography/
│   └── TextStyles.xaml           # TextBlock Styles
├── Controls/
│   ├── Buttons.xaml              # Button Styles
│   ├── Inputs.xaml               # TextBox, ComboBox, etc.
│   ├── Navigation.xaml           # NavigationView, TabBar
│   ├── Data.xaml                 # ListView, ItemsRepeater
│   └── Feedback.xaml             # InfoBar, ProgressRing
└── Layouts/
    ├── Containers.xaml           # Grid, StackPanel Styles
    ├── Pages.xaml                # Page Layouts
    └── Responsive.xaml           # Responsive Helpers
```

## Verwendung

In `App.xaml`:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="ms-appx:///AIRoutine.FullStack.Core.Styles/Styles.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Design-Tokens

### Farben

Semantische Farben verwenden:

```xml
<SolidColorBrush x:Key="PrimaryBrush" Color="{StaticResource PrimaryColor}" />
```

### Spacing

```xml
<x:Double x:Key="SpacingSmall">8</x:Double>
<x:Double x:Key="SpacingMedium">16</x:Double>
<x:Double x:Key="SpacingLarge">24</x:Double>
```

### Typography

```xml
<Style x:Key="TitleLarge" TargetType="TextBlock">
    <!-- ... -->
</Style>
```

## Abhängigkeiten

- Uno.Toolkit.UI - Material Styles
- Microsoft.UI.Xaml - WinUI Controls
