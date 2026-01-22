using AIRoutine.FullStack.App.Presentation;
using AIRoutine.FullStack.Core.Startup;
using AIRoutine.FullStack.Core.Styles;
using Uno.Resizetizer;
using UnoFramework.Converters;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace AIRoutine.FullStack.App;

public partial class App : Application
{
    public App()
    {
        RequestedTheme = ApplicationTheme.Dark;
        ConfigureResources();
    }

    protected Window? MainWindow { get; private set; }

    public IHost? Host { get; private set; }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            .UseToolkitNavigation()
            .Configure(host => host
//-:cnd:noEmit
#if DEBUG
                .UseEnvironment(Environments.Development)
#endif
//+:cnd:noEmit
                .UseLogging(configure: (context, logBuilder) =>
                {
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)
                        .CoreLogLevel(LogLevel.Warning);
                }, enableUnoLogging: true)
                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                        .Section<AppConfig>()
                )
                .UseLocalization()
                .ConfigureServices((context, services) =>
                {
                    services.AddAppServices();
                    services.AddTransient<Shell>();
                })
                .UseNavigation(RegisterRoutes)
            );
        MainWindow = builder.Window;

//-:cnd:noEmit
#if DEBUG
        MainWindow.UseStudio();
#endif
//+:cnd:noEmit
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>();
    }

    private void ConfigureResources()
    {
        Resources.MergedDictionaries.Add(new XamlControlsResources());
        // TODO: ToolkitResources causes resource loading issues on Skia Desktop
        // Resources.MergedDictionaries.Add(new ToolkitResources());
#pragma warning disable ACS0002 // Static call is required for AppStyles factory method
        Resources.MergedDictionaries.Add(AppStyles.Create());
#pragma warning restore ACS0002

        Resources["NullToCollapsedConverter"] = new NullToCollapsedConverter();
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            new ViewMap<Shell, ShellViewModel>(),
            new ViewMap<HeaderPage, HeaderViewModel>(),
            new ViewMap<FooterPage, FooterViewModel>(),
            new ViewMap<MainPage, MainViewModel>(),
            new ViewMap<SecondPage, SecondViewModel>()
        );

        routes.Register(
            new RouteMap("", View: views.FindByViewModel<ShellViewModel>(),
                Nested:
                [
                    new ("HeaderRegion", View: views.FindByViewModel<HeaderViewModel>()),
                    new ("FooterRegion", View: views.FindByViewModel<FooterViewModel>()),
                    new ("ContentRegion", View: views.FindByViewModel<MainViewModel>(),
                        Nested:
                        [
                            new ("Main", View: views.FindByViewModel<MainViewModel>()),
                            new ("Second", View: views.FindByViewModel<SecondViewModel>())
                        ]
                    )
                ]
            )
        );
    }
}
