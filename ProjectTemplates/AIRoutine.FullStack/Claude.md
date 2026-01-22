# AIRoutine.FullStack

## Technische Details

- **Sprache:** C# latest
- **Framework:** .NET 10
- **Frontend:** Uno Platform (nutze Uno MCP und definierte Skills)
- **Backend:** ASP.NET (nutze Microsoft Docs MCP und definierte Skills)
- **Architektur:** Shiny Mediator Pattern ([GitHub](https://github.com/shinyorg/mediator))

## Architekturprinzip: Backend-First

**Alle Logik im Backend. Frontend nur für Anzeige.**

| Backend (API) | Frontend (Uno) |
|---------------|----------------|
| Geschäftslogik, Validierung, Berechnungen | UI, Navigation, API-Aufrufe |
| Datenbank, Security, externe Services | Loading-States, UX-Feedback |

## Dependency Injection

Nutze `Shiny.Extensions.DependencyInjection` für automatische Service-Registrierung.

### Attribute

**API-Services:**
```csharp
using AIRoutine.FullStack.Api;

[Service(ApiService.Lifetime, TryAdd = ApiService.TryAdd)]
public class MyService : IMyService { }
```

**Uno-Services:**
```csharp
using AIRoutine.FullStack;

[Service(UnoService.Lifetime, TryAdd = UnoService.TryAdd)]
public class MyService : IMyService { }
```

### Registrierung

```csharp
services.AddShinyServiceRegistry();
```

### Konstanten

| Klasse | Namespace | Projekt | Lifetime | TryAdd |
|--------|-----------|---------|----------|--------|
| `ApiService` | `AIRoutine.FullStack.Api` | `src/api/src/Shared/Api.Shared` | `Scoped` | `true` |
| `UnoService` | `AIRoutine.FullStack` | `src/uno/src/Shared/Shared` | `Singleton` | `true` |

Referenz: [shinylib.net/extensions/di](https://shinylib.net/extensions/di/)

## Projektstruktur

```
AIRoutine.FullStack/
├── src/
│   ├── api/                        # Backend (ASP.NET)
│   │   └── src/
│   │       ├── *.Api/                             # Host
│   │       ├── *.Api.Contracts/                   # Globale DTOs
│   │       ├── *.Api.Handlers/                    # Globale Handler
│   │       ├── Shared/
│   │       │   └── *.Api.Shared/                  # ApiService DI-Konstanten
│   │       ├── Core/
│   │       │   ├── *.Api.Core.Data/               # DbContext, BaseEntity
│   │       │   └── *.Api.Core.Startup/            # DI Setup
│   │       └── Features/{Name}/
│   │           ├── *.Api.Features.{Name}/         # Services, Data, Handlers
│   │           └── *.Api.Features.{Name}.Contracts/
│   │
│   └── uno/                        # Frontend (Uno Platform)
│       └── src/
│           ├── *.App/                             # Hauptprojekt
│           ├── Shared/
│           │   └── *.Shared/                      # UnoService DI-Konstanten
│           ├── Core/
│           │   ├── *.Core.Startup/                # DI Setup
│           │   └── *.Core.Styles/                 # Design System
│           └── Features/{Name}/
│               ├── *.Features.{Name}/             # Services, Presentation
│               └── *.Features.{Name}.Contracts/
│
└── subm/uno/                       # UnoFramework Submodule
```

> `*` = `AIRoutine.FullStack` Namespace-Prefix

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
1. **Hauptprojekt** (`Api.Features.{FeatureName}`) - Services, Data, Handlers
2. **Contracts-Projekt** (`Api.Features.{FeatureName}.Contracts`) - Request/Response DTOs

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
├── Handlers/
│   └── {Action}Handler.cs                # IRequestHandler<TRequest, TResponse>
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

### Feature Registration

Features werden in `Core.Startup/ServiceCollectionExtensions.cs` registriert:

```csharp
public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
{
    services.AddShinyServiceRegistry();  // [Service] Attribute scannen
    services.AddShinyMediator();
    services.AddAppData(configuration);  // Zentraler DbContext
    services.Add{FeatureName}Feature();
    return services;
}
```

### Entity Configuration Pattern

Entities erben von `BaseEntity` und werden via `IEntityTypeConfiguration<T>` konfiguriert:

### Datenbank-Konfiguration

Die Datenbank verwendet SQLite. Der Connection-String wird in `appsettings.json` konfiguriert:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

**Auto-Discovery:** Entities die von `BaseEntity` erben und `IEntityTypeConfiguration<T>` Implementierungen werden automatisch aus allen `AIRoutine.FullStack.*` Assemblies geladen - keine manuelle Registrierung noetig.

### Mock-Daten / Seeding

Seeder werden im Projekt `Core.Data.Seeding` verwaltet und beim API-Start automatisch ausgefuehrt.

**Seeder erstellen im Feature:**

```csharp
// Features/{Name}/Data/Seeding/{Name}Seeder.cs
using AIRoutine.FullStack.Api.Core.Data;
using AIRoutine.FullStack.Api.Core.Data.Seeding;
using Microsoft.EntityFrameworkCore;

public class MyFeatureSeeder(AppDbContext dbContext) : ISeeder
{
    public int Order => 10; // Reihenfolge (niedrig = zuerst)

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        // Idempotent: Nur seeden wenn leer
        if (await dbContext.Set<MyEntity>().AnyAsync(cancellationToken))
            return;

        dbContext.Set<MyEntity>().AddRange(
            new MyEntity { Name = "Test 1" },
            new MyEntity { Name = "Test 2" }
        );

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
```

**Seeder registrieren:**

```csharp
// In Feature ServiceCollectionExtensions.cs
using AIRoutine.FullStack.Api.Core.Data.Seeding.Configuration;

public static IServiceCollection AddMyFeature(this IServiceCollection services)
{
    services.AddSeeder<MyFeatureSeeder>();
    return services;
}
```

**Wichtig:**
- Seeder MUSS idempotent sein (pruefen ob Daten existieren)
- Mindestens 5-10 realistische Eintraege pro Entity
- Datenbank wird NICHT geloescht, Daten wachsen kontinuierlich

### Shiny.Mediator HTTP Endpoints

API-Handler mit automatischer OpenAPI-Generierung und Endpoint-Registrierung.

**Package Requirements:**
```xml
<ItemGroup>
  <FrameworkReference Include="Microsoft.AspNetCore.App" />
  <PackageReference Include="Shiny.Mediator.AspNet" />
</ItemGroup>
```

**Handler mit MediatorHttpGet:**
```csharp
using AIRoutine.FullStack.Api;
using Shiny.Extensions.DependencyInjection;
using Shiny.Mediator;

[Service(ApiService.Lifetime, TryAdd = ApiService.TryAdd)]
public class GetItemsHandler(AppDbContext dbContext) : IRequestHandler<GetItemsRequest, GetItemsResponse>
{
    [MediatorHttpGet("/api/items", OperationId = "GetItems")]
    public async Task<GetItemsResponse> Handle(GetItemsRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        // Implementation
    }
}
```

**Endpoint Registrierung:**
```csharp
// In Core.Startup/ServiceCollectionExtensions.cs
public static WebApplication MapEndpoints(this WebApplication app)
{
    app.MapGeneratedMediatorEndpoints(); // Automatisch generiert
    return app;
}
```

**WICHTIG - Response Types:**
- NIEMALS nullable Response Types verwenden (`IRequest<ItemDto?>`)
- IMMER Wrapper Response Record verwenden:
```csharp
// FALSCH:
public record GetItemByIdRequest(Guid Id) : IRequest<ItemDto?>;

// RICHTIG:
public record GetItemByIdRequest(Guid Id) : IRequest<GetItemByIdResponse>;
public record GetItemByIdResponse(ItemDto? Item);
```

### API Enum Best Practices

Enums MUESSEN mit `JsonStringEnumConverter` annotiert werden fuer korrekte OpenAPI-Generierung:

```csharp
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemType
{
    TypeA = 1,
    TypeB = 2
}
```

Dies stellt sicher, dass:
- OpenAPI Schema die Enum-Werte als Strings enthaelt
- Der MediatorHttp Source Generator die Enums korrekt generiert
- Der Uno ApiClient die Enum-Typen erhaelt

### SQLite Limitierungen

**DateTimeOffset in ORDER BY:**
SQLite unterstuetzt DateTimeOffset nicht direkt in ORDER BY Klauseln.

```csharp
// FALSCH - Runtime-Fehler:
var items = await query
    .OrderByDescending(x => x.CreatedAt)  // DateTimeOffset
    .ToListAsync(cancellationToken);

// RICHTIG - In-Memory Sortierung:
var entities = await query.ToListAsync(cancellationToken);
var items = entities
    .OrderByDescending(x => x.CreatedAt)
    .ToList();
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
    services.AddShinyServiceRegistry();  // [Service] Attribute scannen
    services.AddShinyMediator();
    services.AddSingleton<IEventCollector, UnoEventCollector>();
    services.AddSingleton<BaseServices>();

    // Features
    services.Add{FeatureName}Feature();

    return services;
}
```

### Uno Feature Beispiel: Auth

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
