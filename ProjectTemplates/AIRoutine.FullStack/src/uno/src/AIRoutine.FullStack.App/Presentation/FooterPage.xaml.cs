using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class FooterPage : UserControl
{
    public FooterPage()
    {
        var rootGrid = new Grid
        {
            Background = (Microsoft.UI.Xaml.Media.Brush)Application.Current.Resources["SurfaceBrush"],
            Padding = new Thickness(16, 12, 16, 12)
        };
        rootGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        rootGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        rootGrid.SetValue(AutomationProperties.AutomationIdProperty, "FooterPage.Root");

#pragma warning disable ACS0002 // Static call is required for SafeArea attached property
        SafeArea.SetInsets(rootGrid, SafeArea.InsetMask.Bottom | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        var separator = new Border
        {
            Height = 1,
            Background = (Microsoft.UI.Xaml.Media.Brush)Application.Current.Resources["DividerBrush"],
            Margin = new Thickness(0, 0, 0, 8)
        };
        Grid.SetRow(separator, 0);

        var footerText = new TextBlock
        {
            Text = "Footer",
            Style = (Style)Application.Current.Resources["TitleMediumTextStyle"],
            HorizontalAlignment = HorizontalAlignment.Center
        };
        footerText.SetValue(AutomationProperties.AutomationIdProperty, "FooterPage.FooterText");
        Grid.SetRow(footerText, 1);

        rootGrid.Children.Add(separator);
        rootGrid.Children.Add(footerText);

        Content = rootGrid;
    }
}
