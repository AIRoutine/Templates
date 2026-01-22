using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;
using UnoFramework.Controls;

namespace AIRoutine.FullStack.App.Presentation;

public sealed partial class HeaderPage : UserControl
{
    public HeaderPage()
    {
        var rootGrid = new Grid
        {
            Background = (Microsoft.UI.Xaml.Media.Brush)Application.Current.Resources["SurfaceBrush"],
            Padding = new Thickness(16, 12, 16, 12)
        };
        rootGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        rootGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        rootGrid.SetValue(AutomationProperties.AutomationIdProperty, "HeaderPage.Root");

#pragma warning disable ACS0002 // Static call is required for SafeArea attached property
        SafeArea.SetInsets(rootGrid, SafeArea.InsetMask.Top | SafeArea.InsetMask.Left | SafeArea.InsetMask.Right);
#pragma warning restore ACS0002

        var headerText = new TextBlock
        {
            Text = "Header",
            Style = (Style)Application.Current.Resources["TitleMediumTextStyle"],
            HorizontalAlignment = HorizontalAlignment.Center
        };
        headerText.SetValue(AutomationProperties.AutomationIdProperty, "HeaderPage.HeaderText");
        Grid.SetRow(headerText, 0);

        var separator = new Border
        {
            Height = 1,
            Background = (Microsoft.UI.Xaml.Media.Brush)Application.Current.Resources["DividerBrush"],
            Margin = new Thickness(0, 8, 0, 0)
        };
        Grid.SetRow(separator, 1);

        rootGrid.Children.Add(headerText);
        rootGrid.Children.Add(separator);

        Content = rootGrid;
    }
}
