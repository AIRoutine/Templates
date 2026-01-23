using Android.Runtime;

namespace AIRoutine.FullStack.App.Platforms.Android;

[global::Android.App.ApplicationAttribute(
    Label = "@string/ApplicationName",
    Icon = "@mipmap/icon",
    LargeHeap = true,
    HardwareAccelerated = true,
    Theme = "@style/Theme.App.Starting"
)]
public class Application(nint javaReference, JniHandleOwnership transfer)
    : Microsoft.UI.Xaml.NativeApplication(() => new App(), javaReference, transfer)
{
}
