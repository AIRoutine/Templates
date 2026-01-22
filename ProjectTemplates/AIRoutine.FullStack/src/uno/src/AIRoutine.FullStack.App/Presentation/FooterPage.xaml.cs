using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class FooterPage : UserControl
{
    public FooterPage()
    {
        var grid = new Grid()
            .Background(x => x.StaticResource("SurfaceBrush"))
            .Padding(16, 12, 16, 12)
            .AutomationProperties(ap => ap.AutomationId("FooterPage.Root"));

#pragma warning disable ACS0002
        SafeArea.SetInsets(grid, SafeArea.InsetMask.Bottom | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var separator = new Border()
            .Height(1)
            .Background(x => x.StaticResource("DividerBrush"))
            .Margin(0, 0, 0, 8);
        Grid.SetRow(separator, 0);

        var footerText = new TextBlock()
            .Text("Footer")
            .Style(x => x.StaticResource("TitleMediumTextStyle"))
            .HorizontalAlignment(HorizontalAlignment.Center)
            .AutomationProperties(ap => ap.AutomationId("FooterPage.FooterText"));
        Grid.SetRow(footerText, 1);

        grid.Children.Add(separator);
        grid.Children.Add(footerText);

        Content = grid;
    }
}
