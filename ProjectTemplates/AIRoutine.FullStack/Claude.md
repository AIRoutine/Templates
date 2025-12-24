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
│   │       │   │   ├── AppDbContext.cs                    # Multi-Provider DbContext
│   │       │   │   ├── Configuration/
│   │       │   │   │   └── ServiceCollectionExtensions.cs # AddAppData()
│   │       │   │   └── Entities/
│   │       │   │       └── BaseEntity.cs                  # Id, CreatedAt, UpdatedAt
│   │       │   │
│   │       │   └── AIRoutine.FullStack.Api.Core.Startup/  # API DI Setup
│   │       │       ├── AIRoutine.FullStack.Api.Core.Startup.csproj
│   │       │       └── ServiceCollectionExtensions.cs     # AddApiServices()
│   │       │
│   │       └── Features/
│   │           └── Auth/                       # Auth Feature
│   │               ├── AIRoutine.FullStack.Api.Features.Auth/
│   │               │   ├── AIRoutine.FullStack.Api.Features.Auth.csproj
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
│   │               │   └── Mediator/
│   │               │       └── Requests/
│   │               │           ├── RefreshRequest.cs
│   │               │           ├── SignInRequest.cs
│   │               │           └── SignOutRequest.cs
│   │               │
│   │               └── AIRoutine.FullStack.Api.Features.Auth.Handlers/
│   │                   ├── AIRoutine.FullStack.Api.Features.Auth.Handlers.csproj
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
│           └── Core/
│               └── AIRoutine.FullStack.Core.Startup/      # Uno DI Setup
│                   ├── AIRoutine.FullStack.Core.Startup.csproj
│                   └── ServiceCollectionExtensions.cs     # AddAppServices()
│
└── subm/
    └── uno/                                    # UnoFramework Submodule
```

## API Feature-Erweiterungsstruktur

Bei neuen API-Features erstelle Projekte unter `src/api/src/Features/{FeatureName}/`:
1. **Hauptprojekt** (`Api.Features.{FeatureName}`) - Services, Data, Configuration
2. **Contracts-Projekt** (`Api.Features.{FeatureName}.Contracts`) - Request/Response DTOs
3. **Handlers-Projekt** (`Api.Features.{FeatureName}.Handlers`) - Business-Logik

### Namenskonventionen

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/api/src/Features/` | `AIRoutine.FullStack.Api.Features.{FeatureName}` |
| Core Features | `src/api/src/Core/` | `AIRoutine.FullStack.Api.Core.{FeatureName}` |

### API Feature Hauptprojekt

```
src/api/src/Features/{FeatureName}/AIRoutine.FullStack.Api.Features.{FeatureName}/
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
└── Mediator/
    └── Requests/
        ├── {Action}Request.cs            # IRequest<TResponse>
        └── {Action}Response.cs           # Response DTO (embedded record)
```

### API Handlers-Projekt

```
src/api/src/Features/{FeatureName}/AIRoutine.FullStack.Api.Features.{FeatureName}.Handlers/
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

### Namenskonventionen

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/uno/src/Features/` | `AIRoutine.FullStack.Features.FeatureName` |
| Core Features | `src/uno/src/Core/` | `AIRoutine.FullStack.Core.FeatureName` |
| Third Party | `src/uno/src/ThirdParty/` | `AIRoutine.FullStack.ThirdParty.FeatureName` |

### Contracts-Projekt

```
src/uno/src/Features/AIRoutine.FullStack.Features.{FeatureName}.Contracts/
├── Models/                       # Data Transfer Objects
├── Enums/                        # Shared Enumerations
├── Interfaces/                   # Service-Interfaces
└── Mediator/
    ├── Commands/                 # Command-Contracts (ICommand)
    ├── Requests/                 # Request-Contracts (IRequest<TResult>)
    ├── Events/                   # Event-Contracts (IEvent)
    └── Navigations/              # Navigation-Contracts
```

### Hauptprojekt

```
src/uno/src/Features/AIRoutine.FullStack.Features.{FeatureName}/
├── Configuration/                # DI Setup, Extensions, Registrierung
├── Domain/                       # Entities, Value Objects, Aggregates
├── Mediator/
│   ├── Commands/                 # Command-Handler
│   ├── Requests/                 # Request-Handler
│   ├── Events/                   # Event-Handler
│   └── Middlewares/              # Mediator-Middlewares
└── Presentation/                 # UI Vertical Slices
    └── {Bereich}/
        ├── {Bereich}ViewModel.cs
        └── {Bereich}Page.xaml
```
