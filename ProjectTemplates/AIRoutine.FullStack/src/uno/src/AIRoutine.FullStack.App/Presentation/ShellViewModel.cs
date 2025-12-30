using AIRoutine.FullStack.Features.Auth.Contracts.Services;
using AIRoutine.FullStack.Features.Auth.Presentation;

namespace AIRoutine.FullStack.App.Presentation;

public class ShellViewModel
{
    private readonly INavigator _navigator;
    private readonly IAuthService _authService;

    public ShellViewModel(INavigator navigator, IAuthService authService)
    {
        _navigator = navigator;
        _authService = authService;

        _ = Start();
    }

    public async Task Start()
    {
        // Initialize auth state from secure storage
        await _authService.InitializeAsync();

        if (_authService.IsAuthenticated)
        {
            await _navigator.NavigateViewModelAsync<MainViewModel>(this);
        }
        else
        {
            await _navigator.NavigateViewModelAsync<LoginViewModel>(this);
        }
    }
}
