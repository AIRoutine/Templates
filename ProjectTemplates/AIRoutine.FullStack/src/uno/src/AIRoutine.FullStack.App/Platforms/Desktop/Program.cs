using Uno.UI.Hosting;

namespace AIRoutine.FullStack.App.Platforms.Desktop;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
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
