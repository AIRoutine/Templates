using AIRoutine.FullStack.Core.ApiClient.Generated;
using CommunityToolkit.Mvvm.ComponentModel;
using UnoFramework.Generators;
using UnoFramework.ViewModels;

namespace AIRoutine.FullStack.Features.Auth.Presentation;

/// <summary>
/// ViewModel for the Login page.
/// </summary>
public partial class LoginViewModel : PageViewModel
{
    [ObservableProperty]
    private string _title = "Sign In";

    [ObservableProperty]
    private string? _errorMessage;

    [ObservableProperty]
    private bool _hasError;

    public LoginViewModel(BaseServices baseServices) : base(baseServices)
    {
    }

    [UnoCommand]
    private async Task SignInAsync()
    {
        using (BeginBusy("Signing in..."))
        {
            ErrorMessage = null;
            HasError = false;

            var (_, response) = await Mediator.Request(new SignInHttpRequest
            {
                Body = new SignInRequest { Scheme = "default" }
            });

            if (!response.Success)
            {
                ErrorMessage = "Sign-in failed. Please try again.";
                HasError = true;
                return;
            }

            // Navigate to main page after successful sign-in
            await Navigator.NavigateRouteAsync(this, "/Main");
        }
    }

    [UnoCommand]
    private async Task SignInWithProviderAsync(string? provider)
    {
        if (string.IsNullOrEmpty(provider))
        {
            return;
        }

        using (BeginBusy($"Signing in with {provider}..."))
        {
            ErrorMessage = null;
            HasError = false;

            var (_, response) = await Mediator.Request(new SignInHttpRequest
            {
                Body = new SignInRequest { Scheme = provider }
            });

            if (!response.Success)
            {
                ErrorMessage = $"Sign-in with {provider} failed. Please try again.";
                HasError = true;
                return;
            }

            // Navigate to main page after successful sign-in
            await Navigator.NavigateRouteAsync(this, "/Main");
        }
    }
}
