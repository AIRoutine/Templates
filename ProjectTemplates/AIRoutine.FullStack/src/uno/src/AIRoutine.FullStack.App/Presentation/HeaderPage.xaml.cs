using AIRoutine.FullStack.Core.Styles;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class HeaderPage : UserControl
{
    public HeaderPage()
    {
        var grid = new Grid()
            .Style(x => x.StaticResource(StyleKeys.GridStyle))
            .AutomationProperties(ap => ap.AutomationId("HeaderPage.Root"));

#pragma warning disable ACS0002
        SafeArea.SetInsets(grid, SafeArea.InsetMask.Top | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var headerText = new TextBlock()
            .Text("Header")
            .Style(x => x.StaticResource(StyleKeys.TitleMediumTextStyle))
            .HorizontalAlignment(HorizontalAlignment.Center)
            .AutomationProperties(ap => ap.AutomationId("HeaderPage.HeaderText"));
        Grid.SetRow(headerText, 0);

        var separator = new Border()
            .Style(x => x.StaticResource(StyleKeys.BorderStyle))
            .Height(1);
        Grid.SetRow(separator, 1);

        grid.Children.Add(headerText);
        grid.Children.Add(separator);

        Content = grid;
    }
}
