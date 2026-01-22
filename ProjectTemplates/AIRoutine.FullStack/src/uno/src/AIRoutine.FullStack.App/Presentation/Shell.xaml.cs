using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Uno.Toolkit.UI;
using UnoFramework.Contracts.Navigation;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider, IRegionHost
{
    private readonly Grid _mainGrid;
    private readonly ContentControl _contentRegion;

    public ContentControl ContentControl => _contentRegion;

    public string ContentRegionName => Routes.Regions.Content;

    public Shell()
    {
        _mainGrid = new Grid
        {
            Background = (Brush)Application.Current.Resources["BackgroundBrush"]
        };
        _mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        _mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        _mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        // Header
        var headerBorder = new Border
        {
            Background = (Brush)Application.Current.Resources["SurfaceBrush"],
            Padding = new Thickness(16, 12, 16, 12)
        };
        var headerGrid = new Grid();
        headerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        headerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var headerText = new TextBlock
        {
            Text = "Header",
            Style = (Style)Application.Current.Resources["TitleMediumTextStyle"],
            HorizontalAlignment = HorizontalAlignment.Center
        };
        Grid.SetRow(headerText, 0);

        var headerSeparator = new Border
        {
            Height = 1,
            Background = (Brush)Application.Current.Resources["DividerBrush"],
            Margin = new Thickness(0, 8, 0, 0)
        };
        Grid.SetRow(headerSeparator, 1);

        headerGrid.Children.Add(headerText);
        headerGrid.Children.Add(headerSeparator);
        headerBorder.Child = headerGrid;
        Grid.SetRow(headerBorder, 0);

        // Content Region
        _contentRegion = new ContentControl
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalContentAlignment = HorizontalAlignment.Stretch,
            VerticalContentAlignment = VerticalAlignment.Stretch
        };
        _contentRegion.SetValue(AutomationProperties.AutomationIdProperty, "Shell.ContentRegion");
#pragma warning disable ACS0002 // Static call is required for Region attached property
        Region.SetName(_contentRegion, Routes.Regions.Content);
        Region.SetAttached(_contentRegion, true);
#pragma warning restore ACS0002
        Grid.SetRow(_contentRegion, 1);

        // Footer
        var footerBorder = new Border
        {
            Background = (Brush)Application.Current.Resources["SurfaceBrush"],
            Padding = new Thickness(16, 12, 16, 12)
        };
        var footerGrid = new Grid();
        footerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        footerGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var footerSeparator = new Border
        {
            Height = 1,
            Background = (Brush)Application.Current.Resources["DividerBrush"],
            Margin = new Thickness(0, 0, 0, 8)
        };
        Grid.SetRow(footerSeparator, 0);

        var footerText = new TextBlock
        {
            Text = "Footer",
            Style = (Style)Application.Current.Resources["TitleMediumTextStyle"],
            HorizontalAlignment = HorizontalAlignment.Center
        };
        Grid.SetRow(footerText, 1);

        footerGrid.Children.Add(footerSeparator);
        footerGrid.Children.Add(footerText);
        footerBorder.Child = footerGrid;
        Grid.SetRow(footerBorder, 2);

        _mainGrid.Children.Add(headerBorder);
        _mainGrid.Children.Add(_contentRegion);
        _mainGrid.Children.Add(footerBorder);

        Content = _mainGrid;
    }
}
