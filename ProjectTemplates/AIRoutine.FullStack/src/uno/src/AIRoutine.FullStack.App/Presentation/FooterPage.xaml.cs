using AIRoutine.FullStack.Core.Styles;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class FooterPage : BaseRegionControl
{
    public FooterPage()
    {
        this.DataContext<FooterViewModel>((control, vm) => control
            .Content(
                new Grid()
                    .Style(x => x.StaticResource(StyleKeys.GridStyle))
                    .AutomationProperties(ap => ap.AutomationId("FooterPage.Root"))
                    .SafeArea(SafeArea.InsetMask.Bottom | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right)
                    .RowDefinitions("Auto, Auto")
                    .Children(
                        new Border()
                            .Style(x => x.StaticResource(StyleKeys.BorderStyle))
                            .Height(1)
                            .Grid(row: 0),

                        new TextBlock()
                            .Text("Footer")
                            .Style(x => x.StaticResource(StyleKeys.TitleMediumTextStyle))
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .AutomationProperties(ap => ap.AutomationId("FooterPage.FooterText"))
                            .Grid(row: 1)
                    )
            )
        );
    }
}
