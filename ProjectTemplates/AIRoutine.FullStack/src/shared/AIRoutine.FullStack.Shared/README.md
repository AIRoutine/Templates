# AIRoutine.FullStack.Shared

Gemeinsame Abhängigkeiten und Utilities für API und Uno.

## Zweck

- Bereitstellung von `Shiny.Extensions.DependencyInjection` für automatische Service-Registrierung
- Plattform-spezifische DI-Konstanten via `AppService`

## Abhängigkeiten

- `Shiny.Extensions.DependencyInjection` - Automatische DI-Registrierung via Attribute
- `Microsoft.Extensions.DependencyInjection.Abstractions`

## AppService

```csharp
AppService.Lifetime  // API: Scoped, UNO: Singleton
AppService.TryAdd    // immer true
```

## Verwendung

```csharp
[Service(AppService.Lifetime, TryAdd = AppService.TryAdd)]
public class MyService : IMyService { }
```

Registrierung:

```csharp
services.AddShinyServiceRegistry();
```
