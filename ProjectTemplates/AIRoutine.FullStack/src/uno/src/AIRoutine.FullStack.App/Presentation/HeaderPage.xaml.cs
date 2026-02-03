using AIRoutine.FullStack.Core.Styles;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class HeaderPage : BaseRegionControl
{
    public HeaderPage()
    {
        _ = this.DataContext<HeaderViewModel>((control, vm) => control
            .Content(
                new Grid()
                    .Style(x => x.StaticResource(StyleKeys.GridStyle))
                    .AutomationProperties(ap => ap.AutomationId("HeaderPage.Root"))
                    .SafeArea(SafeArea.InsetMask.Top | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right)
                    .RowDefinitions("Auto, Auto")
                    .Children(
                        new TextBlock()
                            .Text("Header")
                            .Style(x => x.StaticResource(StyleKeys.TitleMediumTextStyle))
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .AutomationProperties(ap => ap.AutomationId("HeaderPage.HeaderText"))
                            .Grid(row: 0),

                        new Border()
                            .Style(x => x.StaticResource(StyleKeys.BorderStyle))
                            .Height(1)
                            .Grid(row: 1)
                    )
            )
        );
    }
}
