using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;
using UnoFramework.Contracts.Navigation;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider, IRegionHost
{
    private readonly ContentControl _contentRegion;

    public ContentControl ContentControl => _contentRegion;

    public string ContentRegionName => Routes.Regions.Content;

    public Shell()
    {
        var grid = new Grid()
            .Background(x => x.StaticResource("BackgroundBrush"));

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        // Header
        var headerBorder = new Border()
            .Background(x => x.StaticResource("SurfaceBrush"))
            .Padding(16, 12, 16, 12);
        Grid.SetRow(headerBorder, 0);

        var headerGrid = new Grid();
        headerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        headerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var headerText = new TextBlock()
            .Text("Header")
            .Style(x => x.StaticResource("TitleMediumTextStyle"))
            .HorizontalAlignment(HorizontalAlignment.Center);
        Grid.SetRow(headerText, 0);

        var headerSeparator = new Border()
            .Height(1)
            .Background(x => x.StaticResource("DividerBrush"))
            .Margin(0, 8, 0, 0);
        Grid.SetRow(headerSeparator, 1);

        headerGrid.Children.Add(headerText);
        headerGrid.Children.Add(headerSeparator);
        headerBorder.Child = headerGrid;

        // Content Region
        _contentRegion = new ContentControl()
            .HorizontalAlignment(HorizontalAlignment.Stretch)
            .VerticalAlignment(VerticalAlignment.Stretch)
            .HorizontalContentAlignment(HorizontalAlignment.Stretch)
            .VerticalContentAlignment(VerticalAlignment.Stretch)
            .AutomationProperties(ap => ap.AutomationId("Shell.ContentRegion"));
#pragma warning disable ACS0002
        Region.SetName(_contentRegion, Routes.Regions.Content);
        Region.SetAttached(_contentRegion, true);
#pragma warning restore ACS0002
        Grid.SetRow(_contentRegion, 1);

        // Footer
        var footerBorder = new Border()
            .Background(x => x.StaticResource("SurfaceBrush"))
            .Padding(16, 12, 16, 12);
        Grid.SetRow(footerBorder, 2);

        var footerGrid = new Grid();
        footerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        footerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var footerSeparator = new Border()
            .Height(1)
            .Background(x => x.StaticResource("DividerBrush"))
            .Margin(0, 0, 0, 8);
        Grid.SetRow(footerSeparator, 0);

        var footerText = new TextBlock()
            .Text("Footer")
            .Style(x => x.StaticResource("TitleMediumTextStyle"))
            .HorizontalAlignment(HorizontalAlignment.Center);
        Grid.SetRow(footerText, 1);

        footerGrid.Children.Add(footerSeparator);
        footerGrid.Children.Add(footerText);
        footerBorder.Child = footerGrid;

        grid.Children.Add(headerBorder);
        grid.Children.Add(_contentRegion);
        grid.Children.Add(footerBorder);

        Content = grid;
    }
}
