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
        _ = await _navigator.NavigateRouteAsync(this, RouteRegions.Header).ConfigureAwait(false);
        _ = await _navigator.NavigateRouteAsync(this, RouteRegions.Footer).ConfigureAwait(false);
        _ = await _navigator.NavigateRouteAsync(this, RouteRegions.Content).ConfigureAwait(false);
    }
}
