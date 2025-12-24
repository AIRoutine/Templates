using Uno.UI.Hosting;

namespace AIRoutine.UnoApp.iOS;

public class EntryPoint
{
    public static void Main(string[] args)
    {
        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseAppleUIKit()
            .Build();

        host.Run();
    }
}
