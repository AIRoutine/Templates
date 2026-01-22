using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;
using UnoFramework.Controls;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class SecondPage : Page
{
    public SecondPage()
    {
        NavigationCacheMode = NavigationCacheMode.Required;

        this.DataContext<SecondViewModel>((page, vm) => page
            .Content(
                CreateContent(vm)
            )
        );
    }

    private Grid CreateContent(SecondViewModel vm)
    {
        var rootGrid = new Grid()
            .Style(x => x.StaticResource("PageRootStyle"))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.Root"));

        var busyOverlay = new BusyOverlay();
        busyOverlay.SetValue(AutomationProperties.AutomationIdProperty, "SecondPage.BusyOverlay");
        busyOverlay.SetBinding(BusyOverlay.IsBusyProperty, new Binding { Path = new PropertyPath(nameof(vm.IsBusy)) });
        busyOverlay.SetBinding(BusyOverlay.BusyMessageProperty, new Binding { Path = new PropertyPath(nameof(vm.BusyMessage)) });

        var safeAreaGrid = new Grid();
#pragma warning disable ACS0002
        SafeArea.SetInsets(safeAreaGrid, SafeArea.InsetMask.VisibleBounds);
#pragma warning restore ACS0002
        safeAreaGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        safeAreaGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        var navigationBar = new NavigationBar()
            .Style(x => x.StaticResource("DefaultNavigationBarStyle"))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.NavigationBar"));
        navigationBar.SetBinding(ContentControl.ContentProperty, new Binding { Path = new PropertyPath(nameof(vm.Title)) });

        var backButton = new AppBarButton()
            .Icon(new SymbolIcon(Symbol.Back))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.BackButton"));
        backButton.SetBinding(Button.CommandProperty, new Binding { Path = new PropertyPath(nameof(vm.GoBackCommand)) });
        navigationBar.MainCommand = backButton;
        Grid.SetRow(navigationBar, 0);

        var contentLayout = new AutoLayout()
            .Style(x => x.StaticResource("CenteredContentAutoLayoutStyle"))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.Content"));

#pragma warning disable ACS0002
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
        Grid.SetRow(contentLayout, 1);

        contentLayout.Children.Add(
            new TextBlock()
                .Text("This is the Second Page")
                .Style(x => x.StaticResource("HeadlineLargeCenteredTextStyle"))
                .AutomationProperties(ap => ap.AutomationId("SecondPage.HeadlineText"))
        );

        contentLayout.Children.Add(
            new TextBlock()
                .Text("Use the back arrow to return to the main page")
                .Style(x => x.StaticResource("BodyMediumCenteredSubtleTextStyle"))
                .AutomationProperties(ap => ap.AutomationId("SecondPage.SubtitleText"))
        );

        safeAreaGrid.Children.Add(navigationBar);
        safeAreaGrid.Children.Add(contentLayout);
        busyOverlay.Content = safeAreaGrid;
        rootGrid.Children.Add(busyOverlay);

        return rootGrid;
    }
}
