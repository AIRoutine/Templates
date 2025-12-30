# AIRoutine.FullStack.Features.Auth

Authentifizierungs-Feature für die Uno Platform App mit JWT-basierter Benutzerauthentifizierung.

## Zweck

- Token-Management (JWT und Refresh-Token)
- Secure Storage für Authentifizierungsdaten
- Middleware für automatische Token-Verarbeitung nach API-Aufrufen
- Login-UI (Page und ViewModel)

## Architektur

Die Auth-Logik nutzt direkt die **generierten HTTP-Contracts** aus dem ApiClient-Projekt.
Middleware verarbeitet die API-Responses und speichert/löscht Tokens automatisch.

```
UI (ViewModel)
    ↓ SignInHttpRequest
Generated HTTP Handler (macht API-Call)
    ↓ SignInResponse
SignInMiddleware (speichert Tokens)
    ↓
AuthService (Secure Storage)
```

## Struktur

```
Auth/
├── Configuration/
│   └── ServiceCollectionExtensions.cs  # AddAuthFeature()
├── Services/
│   ├── AuthService.cs                  # Token-Management (Secure Storage)
│   └── AuthHeaderContributor.cs        # Fügt Bearer-Token zu Requests hinzu
├── Middleware/
│   ├── SignInMiddleware.cs             # Speichert Tokens nach SignIn
│   └── RefreshMiddleware.cs            # Aktualisiert Tokens nach Refresh
└── Presentation/
    ├── LoginPage.xaml
    ├── LoginPage.xaml.cs
    └── LoginViewModel.cs
```

## Verwendete generierte HTTP-Contracts

Die ViewModels rufen direkt die generierten HTTP-Requests auf:

| Aktion      | Generierter Request          | Middleware              |
|-------------|------------------------------|-------------------------|
| Sign-In     | `SignInHttpRequest`          | `SignInMiddleware`      |
| Refresh     | `RefreshAuthHttpRequest`     | `RefreshMiddleware`     |
| Sign-Out    | `SignOutHttpRequest`         | (direkt ClearTokens)    |

Die Contracts werden in `Core.ApiClient.csproj` via `MediatorHttp` aus der OpenAPI-Spezifikation generiert.

## Öffentliche APIs

### IAuthService

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

### ServiceCollectionExtensions

```csharp
services.AddAuthFeature();
```

## Abhängigkeiten

- `AIRoutine.FullStack.Features.Auth.Contracts` - IAuthService Interface
- `AIRoutine.FullStack.Core.ApiClient` - Generierte HTTP-Contracts
- `UnoFramework` - BaseServices, PageViewModel
- `Uno.Extensions.Storage` - IKeyValueStorage

## Verwendung

### Feature registrieren

In `Core.Startup/ServiceCollectionExtensions.cs`:

```csharp
services.AddAuthFeature();
```

### Navigation zur Login-Page

```csharp
await Navigator.NavigateRouteAsync(this, "/Login");
```

### Auth-Status prüfen

```csharp
// Direkt über IAuthService
if (!authService.IsAuthenticated)
{
    await Navigator.NavigateRouteAsync(this, "/Login");
}
```

### Sign-In durchführen

```csharp
// Im ViewModel - nutzt generierten HTTP-Request direkt
var (_, response) = await Mediator.Request(new SignInHttpRequest
{
    Body = new SignInRequest { Scheme = "Microsoft" }
});

if (response.Success)
{
    // Tokens werden automatisch via SignInMiddleware gespeichert
    await Navigator.NavigateRouteAsync(this, "/Main");
}
```

### Sign-Out durchführen

```csharp
// API-Call + Tokens löschen
await Mediator.Send(new SignOutHttpRequest
{
    Body = new SignOutCommand { RefreshToken = refreshToken }
});
await authService.ClearTokensAsync();
```
