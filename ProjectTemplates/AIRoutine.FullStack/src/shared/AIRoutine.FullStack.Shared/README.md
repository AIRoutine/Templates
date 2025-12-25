# AIRoutine.FullStack.Shared

Gemeinsame Abhängigkeiten und Utilities für API und Uno.

## Zweck

- Bereitstellung von `Shiny.Extensions.DependencyInjection` für automatische Service-Registrierung
- Plattform-spezifische Lifetime-Konstanten via `AppLifetime`

## Abhängigkeiten

- `Shiny.Extensions.DependencyInjection` - Automatische DI-Registrierung via Attribute
- `Microsoft.Extensions.DependencyInjection.Abstractions`

## AppLifetime

Plattform-spezifische ServiceLifetime-Konstanten:

```csharp
// API (#if API):     Default = Scoped
// UNO (#elif UNO):   Default = Singleton
AppLifetime.Default
AppLifetime.Singleton
AppLifetime.Transient
AppLifetime.Scoped
```

## Verwendung

```csharp
[Service(AppLifetime.Default, TryAdd = true)]
public class MyService : IMyService { }
```

Registrierung:

```csharp
services.AddShinyServiceRegistry();
```
