# AIRoutine.FullStack.Core.Startup

Zentrales DI-Setup für die Uno Platform App.

## Zweck

- Zentrale Dependency Injection Konfiguration für die App
- Registrierung von Shiny Mediator
- Bereitstellung von UnoFramework-Services
- Orchestrierung aller Feature-Registrierungen

## Öffentliche APIs

### ServiceCollectionExtensions

```csharp
services.AddAppServices();
```

Registriert:
- Shiny Mediator für CQRS-Pattern
- `UnoEventCollector` für Event-Handling
- `BaseServices` für ViewModel-Basisservices

## Abhängigkeiten

- Shiny.Mediator - Mediator Pattern
- UnoFramework - BaseServices, UnoEventCollector

## Verwendung

In `App.xaml.cs` oder Host-Builder:

```csharp
services.AddAppServices();
```

## Neue Features hinzufügen

Bei neuen Features die Registrierung ergänzen:

```csharp
public static IServiceCollection AddAppServices(this IServiceCollection services)
{
    services.AddShinyMediator();
    services.AddSingleton<IEventCollector, UnoEventCollector>();
    services.AddSingleton<BaseServices>();

    // Features
    services.Add{NeuesFeature}Feature();  // Hier hinzufügen

    return services;
}
```
