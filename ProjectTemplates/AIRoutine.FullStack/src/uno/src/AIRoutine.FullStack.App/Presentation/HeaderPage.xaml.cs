using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class HeaderPage : UserControl
{
    public HeaderPage()
    {
        var grid = new Grid()
            .Background(x => x.StaticResource("SurfaceBrush"))
            .Padding(16, 12, 16, 12)
            .AutomationProperties(ap => ap.AutomationId("HeaderPage.Root"));

#pragma warning disable ACS0002
        SafeArea.SetInsets(grid, SafeArea.InsetMask.Top | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var headerText = new TextBlock()
            .Text("Header")
            .Style(x => x.StaticResource("TitleMediumTextStyle"))
            .HorizontalAlignment(HorizontalAlignment.Center)
            .AutomationProperties(ap => ap.AutomationId("HeaderPage.HeaderText"));
        Grid.SetRow(headerText, 0);

        var separator = new Border()
            .Height(1)
            .Background(x => x.StaticResource("DividerBrush"))
            .Margin(0, 8, 0, 0);
        Grid.SetRow(separator, 1);

        grid.Children.Add(headerText);
        grid.Children.Add(separator);

        Content = grid;
    }
}
