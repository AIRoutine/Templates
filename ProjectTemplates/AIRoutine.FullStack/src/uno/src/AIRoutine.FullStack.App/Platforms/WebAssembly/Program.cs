using Uno.UI.Hosting;

namespace AIRoutine.FullStack.App.Platforms.WebAssembly;

#pragma warning disable ACS0002 // UnoPlatformHostBuilder requires static call - Uno Platform entry point requirement
public static class Program
{
    public static async Task Main(string[] args)
    {
        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseWebAssembly()
            .Build();

        await host.RunAsync();
    }
}
#pragma warning restore ACS0002
