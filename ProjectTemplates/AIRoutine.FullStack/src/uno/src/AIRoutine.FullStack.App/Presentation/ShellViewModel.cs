namespace AIRoutine.FullStack.App.Presentation;

public class ShellViewModel
{
    private readonly INavigator _navigator;

    public ShellViewModel(INavigator navigator)
    {
        _navigator = navigator;

        _ = Start();
    }

    public async Task Start()
    {
        await _navigator.NavigateRouteAsync(this, Routes.Regions.Header);
        await _navigator.NavigateRouteAsync(this, Routes.Regions.Footer);
        await _navigator.NavigateRouteAsync(this, Routes.Regions.Content);
    }
}
