using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider
{
    private readonly ExtendedSplashScreen _splash;
    private readonly Frame _rootFrame;

    public ContentControl ContentControl => _splash;

    public Frame NavigationFrame => _rootFrame;

    public Shell()
    {
        _rootFrame = new Frame();
        _splash = BuildSplash();

        var root = new Border();
        root.SetValue(AutomationProperties.AutomationIdProperty, "Shell.Root");
        root.Background = (Brush)Application.Current.Resources["BackgroundBrush"];
        root.Child = _splash;

        Content = root;
    }

    private ExtendedSplashScreen BuildSplash()
    {
        var loadingGrid = new Grid();
        loadingGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
        loadingGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        var loadingRing = new ProgressRing
        {
            IsActive = true,
            Style = (Style)Application.Current.Resources["LargeProgressRingStyle"],
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        loadingRing.SetValue(AutomationProperties.AutomationIdProperty, "Shell.LoadingIndicator");
        Grid.SetRow(loadingRing, 1);

        loadingGrid.Children.Add(loadingRing);

        var splash = new ExtendedSplashScreen
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalContentAlignment = HorizontalAlignment.Stretch,
            VerticalContentAlignment = VerticalAlignment.Stretch,
            LoadingContent = loadingGrid,
            Content = _rootFrame
        };
        splash.SetValue(AutomationProperties.AutomationIdProperty, "Shell.SplashScreen");

        return splash;
    }
}
