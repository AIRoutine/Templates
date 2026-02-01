using AIRoutine.FullStack.Core.Startup;
using AIRoutine.FullStack.Core.Styles;

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

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG
                .UseEnvironment(Environments.Development)
#endif
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

#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>();
    }

    private void ConfigureResources()
    {
        Resources.MergedDictionaries.Add(new XamlControlsResources());
#pragma warning disable ACS0002
        Resources.MergedDictionaries.Add(AppStyles.Create());
#pragma warning restore ACS0002

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
                    new (RouteRegions.Header, View: views.FindByViewModel<HeaderViewModel>()),
                    new (RouteRegions.Footer, View: views.FindByViewModel<FooterViewModel>()),
                    new (RouteRegions.Content, View: views.FindByViewModel<MainViewModel>(),
                        Nested:
                        [
                            new (RoutePages.Main, View: views.FindByViewModel<MainViewModel>()),
                            new (RoutePages.Second, View: views.FindByViewModel<SecondViewModel>())
                        ]
                    )
                ]
            )
        );
    }
}
