using AIRoutine.FullStack.Core.Styles;
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
            .Style(x => x.StaticResource(StyleKeys.PageRootStyle))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.Root"));

        var busyOverlay = new BusyOverlay()
            .AutomationProperties(ap => ap.AutomationId("SecondPage.BusyOverlay"))
            .IsBusy(() => vm.IsBusy)
            .BusyMessage(() => vm.BusyMessage);

        var safeAreaGrid = new Grid();
#pragma warning disable ACS0002
        SafeArea.SetInsets(safeAreaGrid, SafeArea.InsetMask.VisibleBounds);
#pragma warning restore ACS0002
        safeAreaGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        safeAreaGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        var navigationBar = new NavigationBar()
            .Style(x => x.StaticResource(StyleKeys.DefaultNavigationBarStyle))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.NavigationBar"))
            .Content(() => vm.Title);

        var backButton = new AppBarButton()
            .Style(x => x.StaticResource(StyleKeys.AppBarButtonStyle))
            .Icon(new SymbolIcon(Symbol.Back).Style(x => x.StaticResource(StyleKeys.SymbolIconStyle)))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.BackButton"))
            .Command(() => vm.GoBackCommand);
        navigationBar.MainCommand = backButton;
        Grid.SetRow(navigationBar, 0);

        var contentLayout = new AutoLayout()
            .Style(x => x.StaticResource(StyleKeys.CenteredContentAutoLayoutStyle))
            .AutomationProperties(ap => ap.AutomationId("SecondPage.Content"))
            .ResponsivePadding(narrowest: 16, narrow: 20, normal: 24, wide: 32, widest: 48)
            .ResponsiveSpacing(narrowest: 12, narrow: 14, normal: 16, wide: 20, widest: 24);
        Grid.SetRow(contentLayout, 1);

        contentLayout.Children.Add(
            new TextBlock()
                .Text("This is the Second Page")
                .Style(x => x.StaticResource(StyleKeys.HeadlineLargeCenteredTextStyle))
                .AutomationProperties(ap => ap.AutomationId("SecondPage.HeadlineText"))
        );

        contentLayout.Children.Add(
            new TextBlock()
                .Text("Use the back arrow to return to the main page")
                .Style(x => x.StaticResource(StyleKeys.BodyMediumCenteredSubtleTextStyle))
                .AutomationProperties(ap => ap.AutomationId("SecondPage.SubtitleText"))
        );

        safeAreaGrid.Children.Add(navigationBar);
        safeAreaGrid.Children.Add(contentLayout);
        busyOverlay.Content = safeAreaGrid;
        rootGrid.Children.Add(busyOverlay);

        return rootGrid;
    }
}
