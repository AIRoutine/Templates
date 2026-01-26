using AIRoutine.FullStack.Core.Styles;
using UnoFramework.Pages;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class MainPage : BasePage
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
        var safeAreaGrid = new Grid();
        SafeArea.SetInsets(safeAreaGrid, SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);

        var contentLayout = new AutoLayout()
            .Style(x => x.StaticResource(StyleKeys.CenteredContentAutoLayoutStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.Content"))
            .ApplyDefaultResponsiveLayout();

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

        contentLayout.Children.Add(
            new Button()
                .Content("Click Me")
                .Style(x => x.StaticResource(StyleKeys.PrimaryButtonCenteredStyle))
                .AutomationProperties(ap => ap.AutomationId("MainPage.ClickButton"))
                .Command(() => vm.ClickCommand)
        );

        contentLayout.Children.Add(
            new TextBlock()
                .Style(x => x.StaticResource(StyleKeys.TitleLargeCenteredTextStyle))
                .AutomationProperties(ap => ap.AutomationId("MainPage.ClickCountText"))
                .Text(() => vm.ClickCount)
        );

        contentLayout.Children.Add(
            new Button()
                .Content("Go to Second Page")
                .Style(x => x.StaticResource(StyleKeys.SecondaryButtonCenteredStyle))
                .AutomationProperties(ap => ap.AutomationId("MainPage.NavigateButton"))
                .Command(() => vm.GoToSecondPageCommand)
        );

        safeAreaGrid.Children.Add(contentLayout);

        var busyOverlay = new BusyOverlay()
            .AutomationProperties(ap => ap.AutomationId("MainPage.BusyOverlay"))
            .IsBusy(() => vm.IsBusy)
            .BusyMessage(() => vm.BusyMessage)
            .Content(safeAreaGrid);

        return new Grid()
            .Style(x => x.StaticResource(StyleKeys.PageRootStyle))
            .AutomationProperties(ap => ap.AutomationId("MainPage.Root"))
            .Children(busyOverlay);
    }
}
