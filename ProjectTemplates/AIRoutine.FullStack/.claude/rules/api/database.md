---
paths:
  - "src/api/src/**"
---

# Datenbank (EF Core + SQLite)

## Konfiguration

Die Datenbank verwendet SQLite. Der Connection-String wird in `appsettings.json` konfiguriert:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

## Entity Configuration Pattern

Entities erben von `BaseEntity` und werden via `IEntityTypeConfiguration<T>` konfiguriert.

**Auto-Discovery:** Entities die von `BaseEntity` erben und `IEntityTypeConfiguration<T>` Implementierungen werden automatisch aus allen `AIRoutine.FullStack.*` Assemblies geladen - keine manuelle Registrierung noetig.

## Mock-Daten / Seeding

Seeder werden im Projekt `Core.Data.Seeding` verwaltet und beim API-Start automatisch ausgefuehrt.

### Seeder erstellen im Feature

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

### Seeder registrieren

```csharp
// In Feature ServiceCollectionExtensions.cs
using AIRoutine.FullStack.Api.Core.Data.Seeding.Configuration;

public static IServiceCollection AddMyFeature(this IServiceCollection services)
{
    services.AddSeeder<MyFeatureSeeder>();
    return services;
}
```

### Wichtig

- Seeder MUSS idempotent sein (pruefen ob Daten existieren)
- Mindestens 5-10 realistische Eintraege pro Entity
- Datenbank wird NICHT geloescht, Daten wachsen kontinuierlich

## SQLite Limitierungen

### DateTimeOffset in ORDER BY

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
