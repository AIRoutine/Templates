---
paths:
  - "src/uno/src/**"
---

# Uno Feature-Struktur

Bei neuen Uno-Features erstelle Projekte unter `src/uno/src/`:
1. **Hauptprojekt** - Implementierungen
2. **Contracts-Projekt** - Interfaces und Mediator-Contracts

**Jedes dieser Projekte MUSS eine `README.md` enthalten.**

## Contracts-Projekt

```
src/uno/src/Features/{FeatureName}/AIRoutine.FullStack.Features.{FeatureName}.Contracts/
├── README.md                     # Projektdokumentation (PFLICHT)
├── Models/                       # Data Transfer Objects
├── Enums/                        # Shared Enumerations
├── Interfaces/                   # Service-Interfaces
└── Mediator/
    └── Requests/
        ├── {Action}Request.cs    # IRequest<TResponse>
        └── {Action}Command.cs    # ICommand
```

## Hauptprojekt

```
src/uno/src/Features/{FeatureName}/AIRoutine.FullStack.Features.{FeatureName}/
├── README.md                     # Projektdokumentation (PFLICHT)
├── Configuration/
│   └── ServiceCollectionExtensions.cs    # Add{FeatureName}Feature()
├── Services/
│   ├── I{Service}.cs             # Service-Interfaces
│   └── {Service}.cs              # Service-Implementierungen
├── Mediator/
│   ├── Commands/                 # Command-Handler
│   ├── Requests/                 # Request-Handler
│   └── Events/                   # Event-Handler
└── Presentation/
    ├── {Page}Page.xaml
    ├── {Page}Page.xaml.cs
    └── {Page}ViewModel.cs
```

## Feature Registration

Features werden in `Core.Startup/ServiceCollectionExtensions.cs` registriert:

```csharp
public static IServiceCollection AddAppServices(this IServiceCollection services)
{
    services.AddShinyServiceRegistry();  // [Service] Attribute scannen
    services.AddShinyMediator();
    services.AddSingleton<IEventCollector, UnoEventCollector>();
    services.AddSingleton<BaseServices>();

    // Features
    services.Add{FeatureName}Feature();

    return services;
}
```

## HttpClient Registrierung

HttpClient-basierte Services erfordern explizite Registrierung:

```csharp
// In Feature Configuration/ServiceCollectionExtensions.cs
public static IServiceCollection AddAuthFeature(this IServiceCollection services)
{
    // HttpClient erfordert explizite Registrierung
    services.AddHttpClient<IAuthApiClient, AuthApiClient>();
    return services;
}
```
