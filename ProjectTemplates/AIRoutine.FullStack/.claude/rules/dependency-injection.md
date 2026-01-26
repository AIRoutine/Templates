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

**Uno Page-Scoped Services (pro Navigation):**
```csharp
[Service(UnoService.PageLifetime, TryAdd = UnoService.TryAdd)]
public class MyPageService : IMyPageService { }
```

## Registrierung

```csharp
services.AddShinyServiceRegistry();
```

## Konstanten

| Klasse | Namespace | Lifetime | PageLifetime | TryAdd |
|--------|-----------|----------|--------------|--------|
| `ApiService` | `AIRoutine.FullStack.Api` | `Scoped` | - | `true` |
| `UnoService` | `AIRoutine.FullStack` | `Singleton` | `Scoped` | `true` |

Referenz: [shinylib.net/extensions/di](https://shinylib.net/extensions/di/)
