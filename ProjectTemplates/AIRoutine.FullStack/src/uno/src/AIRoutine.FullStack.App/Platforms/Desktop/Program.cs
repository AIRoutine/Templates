using Uno.UI.Hosting;

namespace AIRoutine.FullStack.App.Platforms.Desktop;

internal class Program
{
    [STAThread]
#pragma warning disable IDE0060 // Entry point signature requires args parameter
    public static void Main(string[] args)
#pragma warning restore IDE0060
    {
#pragma warning disable ACS0002 // Static call is required for Uno Platform host builder entry point
        var host = UnoPlatformHostBuilder.Create()
#pragma warning restore ACS0002
            .App(() => new App())
            .UseX11()
            .UseLinuxFrameBuffer()
            .UseMacOS()
            .UseWin32()
            .Build();

        host.Run();
    }
}
