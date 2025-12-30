# AIRoutine.FullStack.Features.Auth.Contracts

Service-Interfaces und Shared Types für das Auth-Feature auf der Client-Seite.

## Zweck

- Definition des `IAuthService` Interfaces für Token-Management
- Shared zwischen Auth-Feature und anderen App-Komponenten

> **Hinweis:** Die Mediator-Requests (SignInRequest, RefreshRequest, etc.) wurden durch die
> generierten HTTP-Contracts aus `Core.ApiClient.Generated` ersetzt.
> ViewModels nutzen direkt `SignInHttpRequest`, `RefreshAuthHttpRequest`, etc.

## Struktur

```
Contracts/
└── Services/
    └── IAuthService.cs  # Token-Management Interface
```

## Interfaces

### IAuthService

Verwaltet den Authentifizierungsstatus und Token-Speicherung.

```csharp
public interface IAuthService
{
    bool IsAuthenticated { get; }
    string? CurrentToken { get; }
    string? UserEmail { get; }
    string? DisplayName { get; }

    Task SetTokensAsync(string jwt, string refreshToken, string email, string? displayName = null);
    Task ClearTokensAsync();
    Task<string?> GetRefreshTokenAsync();
    Task InitializeAsync();
}
```

## Verwendung

```csharp
// Auth-Status prüfen
if (authService.IsAuthenticated)
{
    var token = authService.CurrentToken;
    var email = authService.UserEmail;
}

// Tokens setzen (nach Login)
await authService.SetTokensAsync(jwt, refreshToken, email);

// Ausloggen
await authService.ClearTokensAsync();
```

## Abhängigkeiten

- Keine externen Abhängigkeiten (reine Interfaces)
