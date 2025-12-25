# AIRoutine.FullStack

## Technische Details

- **Sprache:** C# latest
- **Framework:** .NET 10
- **Frontend:** Uno Platform (nutze Uno MCP und definierte Skills)
- **Backend:** ASP.NET (nutze Microsoft Docs MCP und definierte Skills)
- **Orchestrierung:** .NET Aspire (AppHost + ServiceDefaults)
- **Architektur:** Shiny Mediator Pattern ([GitHub](https://github.com/shinyorg/mediator))

## Aktuelle Projektstruktur

```
AIRoutine.FullStack/
├── .claude/
│   └── settings.json                           # Claude Code Einstellungen
├── .gitignore
├── .gitmodules
├── Claude.md                                   # Diese Datei
├── Directory.Build.props                       # Zentrale Build-Eigenschaften
├── Directory.Packages.props                    # Zentrale Package-Versionen
├── global.json                                 # SDK-Versionen (Uno.Sdk)
├── AIRoutine.FullStack.slnx                    # Haupt-Solution
│
├── src/
│   ├── api/                                    # Backend API
│   │   ├── Directory.Build.props
│   │   ├── Directory.Packages.props
│   │   ├── api.slnx                            # API Sub-Solution
│   │   │
│   │   └── src/
│   │       ├── AIRoutine.FullStack.Api/        # API Host-Projekt
│   │       │   ├── AIRoutine.FullStack.Api.csproj
│   │       │   ├── Program.cs                  # Entry Point
│   │       │   ├── appsettings.json
│   │       │   ├── appsettings.Development.json
│   │       │   └── Properties/
│   │       │       └── launchSettings.json
│   │       │
│   │       ├── AIRoutine.FullStack.Api.Contracts/
│   │       │   ├── AIRoutine.FullStack.Api.Contracts.csproj
│   │       │   └── Mediator/
│   │       │       └── Requests/
│   │       │
│   │       ├── AIRoutine.FullStack.Api.Handlers/
│   │       │   ├── AIRoutine.FullStack.Api.Handlers.csproj
│   │       │   └── {Feature}Handler.cs
│   │       │
│   │       ├── Core/
│   │       │   ├── AIRoutine.FullStack.Api.Core.Data/     # Zentraler DbContext
│   │       │   │   ├── AIRoutine.FullStack.Api.Core.Data.csproj
│   │       │   │   ├── README.md                          # Projektdokumentation
│   │       │   │   ├── AppDbContext.cs                    # Multi-Provider DbContext
│   │       │   │   ├── Configuration/
│   │       │   │   │   └── ServiceCollectionExtensions.cs # AddAppData()
│   │       │   │   └── Entities/
│   │       │   │       └── BaseEntity.cs                  # Id, CreatedAt, UpdatedAt
│   │       │   │
│   │       │   └── AIRoutine.FullStack.Api.Core.Startup/  # API DI Setup
│   │       │       ├── AIRoutine.FullStack.Api.Core.Startup.csproj
│   │       │       ├── README.md                          # Projektdokumentation
│   │       │       └── ServiceCollectionExtensions.cs     # AddApiServices()
│   │       │
│   │       └── Features/
│   │           └── Auth/                       # Auth Feature
│   │               ├── AIRoutine.FullStack.Api.Features.Auth/
│   │               │   ├── AIRoutine.FullStack.Api.Features.Auth.csproj
│   │               │   ├── README.md                     # Projektdokumentation
│   │               │   ├── Configuration/
│   │               │   │   └── ServiceCollectionExtensions.cs  # AddAuthFeature()
│   │               │   ├── Data/
│   │               │   │   ├── Entities/
│   │               │   │   │   ├── User.cs                # : BaseEntity
│   │               │   │   │   └── RefreshToken.cs        # : BaseEntity
│   │               │   │   └── Configurations/
│   │               │   │       ├── UserConfiguration.cs
│   │               │   │       └── RefreshTokenConfiguration.cs
│   │               │   └── Services/
│   │               │       ├── IUserService.cs
│   │               │       ├── JwtService.cs
│   │               │       └── UserService.cs
│   │               │
│   │               ├── AIRoutine.FullStack.Api.Features.Auth.Contracts/
│   │               │   ├── AIRoutine.FullStack.Api.Features.Auth.Contracts.csproj
│   │               │   ├── README.md                     # Projektdokumentation
│   │               │   └── Mediator/
│   │               │       └── Requests/
│   │               │           ├── RefreshRequest.cs
│   │               │           ├── SignInRequest.cs
│   │               │           └── SignOutRequest.cs
│   │               │
│   │               └── AIRoutine.FullStack.Api.Features.Auth.Handlers/
│   │                   ├── AIRoutine.FullStack.Api.Features.Auth.Handlers.csproj
│   │                   ├── README.md                     # Projektdokumentation
│   │                   ├── RefreshHandler.cs
│   │                   ├── SignInHandler.cs
│   │                   └── SignOutHandler.cs
│   │
│   ├── aspire/                                 # .NET Aspire Orchestrierung
│   │   ├── aspire.slnx                         # Aspire Sub-Solution
│   │   │
│   │   └── src/
│   │       ├── AIRoutine.FullStack.AppHost/    # Aspire Orchestrator
│   │       │   ├── AIRoutine.FullStack.AppHost.csproj
│   │       │   ├── Program.cs                  # Orchestriert API
│   │       │   ├── appsettings.json
│   │       │   └── Properties/
│   │       │       └── launchSettings.json
│   │       │
│   │       └── AIRoutine.FullStack.ServiceDefaults/  # Shared Aspire Config
│   │           ├── AIRoutine.FullStack.ServiceDefaults.csproj
│   │           └── Extensions.cs               # AddServiceDefaults(), MapDefaultEndpoints()
│   │
│   └── uno/                                    # Frontend Uno App
│       ├── Directory.Build.props
│       ├── Directory.Packages.props
│       ├── uno.slnx                            # Uno Sub-Solution
│       │
│       └── src/
│           ├── AIRoutine.FullStack.App/        # Uno Hauptprojekt
│           │   ├── AIRoutine.FullStack.App.csproj
│           │   ├── App.xaml
│           │   ├── App.xaml.cs
│           │   ├── GlobalUsings.cs
│           │   ├── appsettings.json
│           │   ├── appsettings.development.json
│           │   ├── Models/
│           │   ├── Presentation/
│           │   └── Platforms/
│           │
│           ├── Core/
│           │   ├── AIRoutine.FullStack.Core.Startup/      # Uno DI Setup
│           │   │   ├── AIRoutine.FullStack.Core.Startup.csproj
│           │   │   ├── README.md                          # Projektdokumentation
│           │   │   └── ServiceCollectionExtensions.cs     # AddAppServices()
│           │   │
│           │   └── AIRoutine.FullStack.Core.Styles/       # Design System
│           │       ├── AIRoutine.FullStack.Core.Styles.csproj
│           │       ├── README.md
│           │       └── ...                                # Styles, Themes, Controls
│           │
│           └── Features/
│               └── Auth/                                  # Auth Feature
│                   ├── AIRoutine.FullStack.Features.Auth/
│                   │   ├── AIRoutine.FullStack.Features.Auth.csproj
│                   │   ├── README.md                      # Projektdokumentation
│                   │   ├── Configuration/
│                   │   │   └── ServiceCollectionExtensions.cs  # AddAuthFeature()
│                   │   ├── Services/
│                   │   │   ├── IAuthService.cs            # Token-Management
│                   │   │   ├── AuthService.cs
│                   │   │   ├── IAuthApiClient.cs          # API Client
│                   │   │   └── AuthApiClient.cs
│                   │   ├── Mediator/
│                   │   │   └── Requests/
│                   │   │       ├── SignInHandler.cs
│                   │   │       ├── RefreshHandler.cs
│                   │   │       ├── SignOutHandler.cs
│                   │   │       └── GetAuthStateHandler.cs
│                   │   └── Presentation/
│                   │       ├── LoginPage.xaml
│                   │       ├── LoginPage.xaml.cs
│                   │       └── LoginViewModel.cs
│                   │
│                   └── AIRoutine.FullStack.Features.Auth.Contracts/
│                       ├── AIRoutine.FullStack.Features.Auth.Contracts.csproj
│                       ├── README.md                      # Projektdokumentation
│                       └── Mediator/
│                           └── Requests/
│                               ├── SignInRequest.cs
│                               ├── RefreshRequest.cs
│                               ├── SignOutCommand.cs
│                               └── GetAuthStateRequest.cs
│
└── subm/
    └── uno/                                    # UnoFramework Submodule
```

## Projektdokumentation

**Jedes Projekt (Core, Features, ThirdParty) MUSS eine `README.md` Datei im Projektstammverzeichnis enthalten.**

Die README.md dokumentiert:
- Zweck und Verantwortlichkeiten des Projekts
- Öffentliche APIs und Services
- Abhängigkeiten zu anderen Projekten
- Konfigurationsoptionen (falls vorhanden)
- Beispiele zur Verwendung

## API Feature-Erweiterungsstruktur

Bei neuen API-Features erstelle Projekte unter `src/api/src/Features/{FeatureName}/`:
1. **Hauptprojekt** (`Api.Features.{FeatureName}`) - Services, Data, Configuration
2. **Contracts-Projekt** (`Api.Features.{FeatureName}.Contracts`) - Request/Response DTOs
3. **Handlers-Projekt** (`Api.Features.{FeatureName}.Handlers`) - Business-Logik

**Jedes dieser Projekte MUSS eine `README.md` enthalten.**

### Namenskonventionen

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/api/src/Features/` | `AIRoutine.FullStack.Api.Features.{FeatureName}` |
| Core Features | `src/api/src/Core/` | `AIRoutine.FullStack.Api.Core.{FeatureName}` |

### API Feature Hauptprojekt

```
src/api/src/Features/{FeatureName}/AIRoutine.FullStack.Api.Features.{FeatureName}/
├── README.md                             # Projektdokumentation (PFLICHT)
├── Configuration/
│   └── ServiceCollectionExtensions.cs    # Add{FeatureName}Feature()
├── Data/
│   ├── Entities/
│   │   └── {Entity}.cs                   # : BaseEntity
│   └── Configurations/
│       └── {Entity}Configuration.cs      # IEntityTypeConfiguration<T>
└── Services/
    ├── I{Service}.cs                     # Service-Interfaces
    └── {Service}.cs                      # Service-Implementierungen
```

### API Contracts-Projekt

```
src/api/src/Features/{FeatureName}/AIRoutine.FullStack.Api.Features.{FeatureName}.Contracts/
├── README.md                             # Projektdokumentation (PFLICHT)
└── Mediator/
    └── Requests/
        ├── {Action}Request.cs            # IRequest<TResponse>
        └── {Action}Response.cs           # Response DTO (embedded record)
```

### API Handlers-Projekt

```
src/api/src/Features/{FeatureName}/AIRoutine.FullStack.Api.Features.{FeatureName}.Handlers/
├── README.md                             # Projektdokumentation (PFLICHT)
└── {Action}Handler.cs                    # IRequestHandler<TRequest, TResponse>
```

### Feature Registration

Features werden in `Core.Startup/ServiceCollectionExtensions.cs` registriert:

```csharp
public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
{
    services.AddShinyMediator();
    services.AddAppData(configuration);  // Zentraler DbContext
    services.Add{FeatureName}Feature();  // Feature Services
    return services;
}
```

### Entity Configuration Pattern

Entities erben von `BaseEntity` und werden via `IEntityTypeConfiguration<T>` konfiguriert:

```csharp
// In Feature ServiceCollectionExtensions.cs
public static IServiceCollection Add{FeatureName}Feature(this IServiceCollection services)
{
    // Entity Configurations registrieren
    AppDbContext.RegisterConfigurations(typeof({Entity}Configuration).Assembly);

    // Services
    services.AddScoped<I{Service}, {Service}>();
    return services;
}
```

### Datenbank-Konfiguration

Der Datenbank-Provider wird in `appsettings.json` konfiguriert:

```json
{
  "Database": {
    "Provider": "sqlite"  // sqlite, postgresql, sqlserver
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

## Uno Feature-Erweiterungsstruktur

Bei neuen Uno-Features erstelle Projekte unter `src/uno/src/`:
1. **Hauptprojekt** - Implementierungen
2. **Contracts-Projekt** - Interfaces und Mediator-Contracts

**Jedes dieser Projekte MUSS eine `README.md` enthalten.**

### Namenskonventionen

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/uno/src/Features/` | `AIRoutine.FullStack.Features.FeatureName` |
| Core Features | `src/uno/src/Core/` | `AIRoutine.FullStack.Core.FeatureName` |
| Third Party | `src/uno/src/ThirdParty/` | `AIRoutine.FullStack.ThirdParty.FeatureName` |

### Contracts-Projekt

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

### Hauptprojekt

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

### Feature Registration (Uno)

Features werden in `Core.Startup/ServiceCollectionExtensions.cs` registriert:

```csharp
public static IServiceCollection AddAppServices(this IServiceCollection services)
{
    services.AddShinyMediator();
    services.AddSingleton<IEventCollector, UnoEventCollector>();
    services.AddSingleton<BaseServices>();

    // Features
    services.AddAuthFeature();
    services.Add{FeatureName}Feature();  // Feature Services

    return services;
}
```

### Uno Feature Beispiel: Auth

Das Auth-Feature zeigt die empfohlene Struktur:

```csharp
// In Feature Configuration/ServiceCollectionExtensions.cs
public static IServiceCollection AddAuthFeature(this IServiceCollection services)
{
    // Services
    services.AddSingleton<IAuthService, AuthService>();

    // API Client
    services.AddHttpClient<IAuthApiClient, AuthApiClient>();

    return services;
}
```
