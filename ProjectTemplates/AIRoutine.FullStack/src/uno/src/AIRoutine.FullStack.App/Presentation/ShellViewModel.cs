namespace AIRoutine.FullStack.App.Presentation;

public class ShellViewModel
{
    private readonly INavigator _navigator;

    public ShellViewModel(INavigator navigator)
    {
        _navigator = navigator;
        _ = StartAsync();
    }

    public async Task StartAsync()
    {
        await _navigator.NavigateRouteAsync(this, RouteRegions.Header);
        await _navigator.NavigateRouteAsync(this, RouteRegions.Footer);
        await _navigator.NavigateRouteAsync(this, RouteRegions.Content);
    }
}
