using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Uno.Toolkit.UI;
using UnoFramework.Controls;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        NavigationCacheMode = NavigationCacheMode.Required;

        var rootGrid = new Grid
        {
            Style = (Style)Application.Current.Resources["PageRootStyle"]
        };
        rootGrid.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.Root");

        var busyOverlay = new BusyOverlay();
        busyOverlay.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.BusyOverlay");
        busyOverlay.SetBinding(BusyOverlay.IsBusyProperty, new Binding { Path = new PropertyPath("IsBusy") });
        busyOverlay.SetBinding(BusyOverlay.BusyMessageProperty, new Binding { Path = new PropertyPath("BusyMessage") });

        var safeAreaGrid = new Grid();
#pragma warning disable ACS0002 // Static call is required for SafeArea attached property
        SafeArea.SetInsets(safeAreaGrid, SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        var contentLayout = new AutoLayout
        {
            Style = (Style)Application.Current.Resources["CenteredContentAutoLayoutStyle"]
        };
        contentLayout.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.Content");
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
            Text = "Welcome to AIRoutine.FullStack!",
            Style = (Style)Application.Current.Resources["HeadlineLargeCenteredTextStyle"]
        };
        headline.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.HeadlineText");

        var subtitle = new TextBlock
        {
            Text = "Full-Stack: API + Uno App with shared configuration",
            Style = (Style)Application.Current.Resources["BodyMediumCenteredSubtleTextStyle"]
        };
        subtitle.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.SubtitleText");

        var actionButton = new Button
        {
            Content = "Click Me",
            Style = (Style)Application.Current.Resources["PrimaryButtonCenteredStyle"]
        };
        actionButton.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.ClickButton");
        actionButton.SetBinding(Button.CommandProperty, new Binding { Path = new PropertyPath("ClickCommand") });

        var clickCount = new TextBlock
        {
            Style = (Style)Application.Current.Resources["TitleLargeCenteredTextStyle"]
        };
        clickCount.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.ClickCountText");
        clickCount.SetBinding(TextBlock.TextProperty, new Binding
        {
            Path = new PropertyPath("ClickCount"),
            Converter = (IValueConverter)Application.Current.Resources["NullToCollapsedConverter"]
        });

        contentLayout.Children.Add(headline);
        contentLayout.Children.Add(subtitle);
        contentLayout.Children.Add(actionButton);
        contentLayout.Children.Add(clickCount);

        safeAreaGrid.Children.Add(contentLayout);

        busyOverlay.Content = safeAreaGrid;
        rootGrid.Children.Add(busyOverlay);
        Content = rootGrid;
    }
}
