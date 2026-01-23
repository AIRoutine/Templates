using Android.OS;
using Android.Views;

namespace AIRoutine.FullStack.App.Platforms.Android;

[global::Android.App.Activity(
    MainLauncher = true,
    ConfigurationChanges = global::Uno.UI.ActivityHelper.AllConfigChanges,
    WindowSoftInputMode = SoftInput.AdjustNothing | SoftInput.StateHidden
)]
public class MainActivity : Microsoft.UI.Xaml.ApplicationActivity
{
#pragma warning disable ACS0002 // SplashScreen requires static call - Android platform requirement
    protected override void OnCreate(Bundle? bundle)
    {
        global::AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(this);

        base.OnCreate(bundle);
    }
#pragma warning restore ACS0002
}
