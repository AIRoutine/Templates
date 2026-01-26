# Dependency Injection

Nutze `Shiny.Extensions.DependencyInjection` für automatische Service-Registrierung.

## Attribute

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

## Registrierung

```csharp
services.AddShinyServiceRegistry();
```

## Konstanten

| Klasse | Namespace | Projekt | Lifetime | TryAdd |
|--------|-----------|---------|----------|--------|
| `ApiService` | `AIRoutine.FullStack.Api` | `src/api/src/Shared/Api.Shared` | `Scoped` | `true` |
| `UnoService` | `AIRoutine.FullStack` | `src/uno/src/Shared/Shared` | `Singleton` | `true` |

Referenz: [shinylib.net/extensions/di](https://shinylib.net/extensions/di/)
