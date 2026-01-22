using AIRoutine.FullStack.Core.Styles;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class FooterPage : UserControl
{
    public FooterPage()
    {
        var grid = new Grid()
            .Style(x => x.StaticResource(StyleKeys.GridStyle))
            .AutomationProperties(ap => ap.AutomationId("FooterPage.Root"));

#pragma warning disable ACS0002
        SafeArea.SetInsets(grid, SafeArea.InsetMask.Bottom | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var separator = new Border()
            .Style(x => x.StaticResource(StyleKeys.BorderStyle))
            .Height(1);
        Grid.SetRow(separator, 0);

        var footerText = new TextBlock()
            .Text("Footer")
            .Style(x => x.StaticResource(StyleKeys.TitleMediumTextStyle))
            .HorizontalAlignment(HorizontalAlignment.Center)
            .AutomationProperties(ap => ap.AutomationId("FooterPage.FooterText"));
        Grid.SetRow(footerText, 1);

        grid.Children.Add(separator);
        grid.Children.Add(footerText);

        Content = grid;
    }
}
