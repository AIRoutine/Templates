using AIRoutine.FullStack.Core.Styles;
using UnoFramework.Contracts.Navigation;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider, IRegionHost
{
#pragma warning disable IDE0032 // Use auto property
    private readonly ContentControl _contentRegion;
#pragma warning restore IDE0032

    public ContentControl ContentControl => _contentRegion;

    public string ContentRegionName => Routes.Regions.Content;

    public Shell()
    {
        var grid = new Grid()
            .Style(x => x.StaticResource(StyleKeys.GridStyle));

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        // Header
        var headerBorder = new Border()
            .Style(x => x.StaticResource(StyleKeys.BorderStyle));
        Grid.SetRow(headerBorder, 0);

        var headerGrid = new Grid();
        headerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        headerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var headerText = new TextBlock()
            .Text("Header")
            .Style(x => x.StaticResource(StyleKeys.TitleMediumTextStyle))
            .HorizontalAlignment(HorizontalAlignment.Center);
        Grid.SetRow(headerText, 0);

        var headerSeparator = new Border()
            .Style(x => x.StaticResource(StyleKeys.BorderStyle))
            .Height(1);
        Grid.SetRow(headerSeparator, 1);

        headerGrid.Children.Add(headerText);
        headerGrid.Children.Add(headerSeparator);
        headerBorder.Child = headerGrid;

        // Content Region
        _contentRegion = new ContentControl()
            .Style(x => x.StaticResource(StyleKeys.ContentControlStyle))
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
            .Style(x => x.StaticResource(StyleKeys.BorderStyle));
        Grid.SetRow(footerBorder, 2);

        var footerGrid = new Grid();
        footerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        footerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var footerSeparator = new Border()
            .Style(x => x.StaticResource(StyleKeys.BorderStyle))
            .Height(1);
        Grid.SetRow(footerSeparator, 0);

        var footerText = new TextBlock()
            .Text("Footer")
            .Style(x => x.StaticResource(StyleKeys.TitleMediumTextStyle))
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
