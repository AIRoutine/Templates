using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Uno.Toolkit.UI;
using UnoFramework.Controls;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class SecondPage : Page
{
    public SecondPage()
    {
        NavigationCacheMode = NavigationCacheMode.Required;

        var rootGrid = new Grid
        {
            Style = (Style)Application.Current.Resources["PageRootStyle"]
        };
        rootGrid.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.Root");

        var busyOverlay = new BusyOverlay();
        busyOverlay.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.BusyOverlay");
        busyOverlay.SetBinding(BusyOverlay.IsBusyProperty, new Binding { Path = new PropertyPath("IsBusy") });
        busyOverlay.SetBinding(BusyOverlay.BusyMessageProperty, new Binding { Path = new PropertyPath("BusyMessage") });

        var safeAreaGrid = new Grid();
#pragma warning disable ACS0002 // Static call is required for SafeArea attached property
        SafeArea.SetInsets(safeAreaGrid, SafeArea.InsetMask.VisibleBounds);
#pragma warning restore ACS0002
        safeAreaGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        safeAreaGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        var navigationBar = new NavigationBar
        {
            Style = (Style)Application.Current.Resources["DefaultNavigationBarStyle"]
        };
        navigationBar.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.NavigationBar");
        navigationBar.SetBinding(ContentControl.ContentProperty, new Binding { Path = new PropertyPath("Title") });

        // Back button
        var backButton = new AppBarButton
        {
            Icon = new SymbolIcon(Symbol.Back)
        };
        backButton.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.BackButton");
        backButton.SetBinding(Button.CommandProperty, new Binding { Path = new PropertyPath("GoBackCommand") });
        navigationBar.MainCommand = backButton;

        var contentLayout = new AutoLayout
        {
            Style = (Style)Application.Current.Resources["CenteredContentAutoLayoutStyle"]
        };
        contentLayout.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.Content");
        Grid.SetRow(contentLayout, 1);
#pragma warning disable ACS0002 // Static call is required for ResponsiveExtension setup
        ResponsiveExtension.Install(contentLayout, typeof(AutoLayout), nameof(AutoLayout.Padding), new ResponsiveExtension
        {
            Narrowest = 16,
            Narrow = 20,
            Normal = 24,
            Wide = 32,
            Widest = 48
        });
        ResponsiveExtension.Install(contentLayout, typeof(AutoLayout), nameof(AutoLayout.Spacing), new ResponsiveExtension
        {
            Narrowest = 12,
            Narrow = 14,
            Normal = 16,
            Wide = 20,
            Widest = 24
        });
#pragma warning restore ACS0002

        var headline = new TextBlock
        {
            Text = "This is the Second Page",
            Style = (Style)Application.Current.Resources["HeadlineLargeCenteredTextStyle"]
        };
        headline.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.HeadlineText");

        var subtitle = new TextBlock
        {
            Text = "Use the back arrow to return to the main page",
            Style = (Style)Application.Current.Resources["BodyMediumCenteredSubtleTextStyle"]
        };
        subtitle.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.SubtitleText");

        contentLayout.Children.Add(headline);
        contentLayout.Children.Add(subtitle);

        safeAreaGrid.Children.Add(navigationBar);
        safeAreaGrid.Children.Add(contentLayout);

        busyOverlay.Content = safeAreaGrid;
        rootGrid.Children.Add(busyOverlay);
        Content = rootGrid;
    }
}
