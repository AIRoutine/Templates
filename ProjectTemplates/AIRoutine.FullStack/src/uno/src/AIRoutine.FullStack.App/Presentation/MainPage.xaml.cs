using AIRoutine.FullStack.Core.Styles;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;
using UnoFramework.Controls;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        NavigationCacheMode = NavigationCacheMode.Required;

        this.DataContext<MainViewModel>((page, vm) => page
            .Content(
                CreateContent(vm)
            )
        );
    }

    private Grid CreateContent(MainViewModel vm)
    {
        var rootGrid = new Grid()
            .Style(x => x.StaticResource(StyleKeys.PageRootStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.Root"));

        var busyOverlay = new BusyOverlay();
        busyOverlay.SetValue(AutomationProperties.AutomationIdProperty, "MainPage.BusyOverlay");
        busyOverlay.SetBinding(BusyOverlay.IsBusyProperty, new Binding { Path = new PropertyPath(nameof(vm.IsBusy)) });
        busyOverlay.SetBinding(BusyOverlay.BusyMessageProperty, new Binding { Path = new PropertyPath(nameof(vm.BusyMessage)) });

        var safeAreaGrid = new Grid();
        SafeArea.SetInsets(safeAreaGrid, SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);

        var contentLayout = new AutoLayout()
            .Style(x => x.StaticResource(StyleKeys.CenteredContentAutoLayoutStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.Content"));

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

        contentLayout.Children.Add(
            new TextBlock()
                .Text("Welcome to AIRoutine.FullStack!")
                .Style(x => x.StaticResource(StyleKeys.HeadlineLargeCenteredTextStyle))
                .AutomationProperties(ap => ap.AutomationId("MainPage.HeadlineText"))
        );

        contentLayout.Children.Add(
            new TextBlock()
                .Text("Full-Stack: API + Uno App with shared configuration")
                .Style(x => x.StaticResource(StyleKeys.BodyMediumCenteredSubtleTextStyle))
                .AutomationProperties(ap => ap.AutomationId("MainPage.SubtitleText"))
        );

        var clickButton = new Button()
            .Content("Click Me")
            .Style(x => x.StaticResource(StyleKeys.PrimaryButtonCenteredStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.ClickButton"));
        clickButton.SetBinding(Button.CommandProperty, new Binding { Path = new PropertyPath(nameof(vm.ClickCommand)) });
        contentLayout.Children.Add(clickButton);

        var clickCount = new TextBlock()
            .Style(x => x.StaticResource(StyleKeys.TitleLargeCenteredTextStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.ClickCountText"));
        clickCount.SetBinding(TextBlock.TextProperty, new Binding { Path = new PropertyPath(nameof(vm.ClickCount)) });
        contentLayout.Children.Add(clickCount);

        var navigateButton = new Button()
            .Content("Go to Second Page")
            .Style(x => x.StaticResource(StyleKeys.SecondaryButtonCenteredStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.NavigateButton"));
        navigateButton.SetBinding(Button.CommandProperty, new Binding { Path = new PropertyPath(nameof(vm.GoToSecondPageCommand)) });
        contentLayout.Children.Add(navigateButton);

        safeAreaGrid.Children.Add(contentLayout);
        busyOverlay.Content = safeAreaGrid;
        rootGrid.Children.Add(busyOverlay);

        return rootGrid;
    }
}
