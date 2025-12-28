# AIRoutine.FullStack.Features.Auth

Authentifizierungs-Feature für die Uno Platform App mit JWT-basierter Benutzerauthentifizierung.

## Zweck

- Token-Management (JWT und Refresh-Token)
- Secure Storage für Authentifizierungsdaten
- Mediator-Handler für Auth-Operationen (nutzt generierte OpenAPI HTTP-Contracts)
- Login-UI (Page und ViewModel)

## Struktur

```
Auth/
├── Configuration/
│   └── ServiceCollectionExtensions.cs  # AddAuthFeature()
├── Services/
│   ├── IAuthService.cs                 # Token-Management Interface
│   └── AuthService.cs                  # Secure Storage Implementation
├── Mediator/
│   └── Requests/
│       ├── SignInHandler.cs            # Nutzt SignInHttpRequest (OpenAPI)
│       ├── RefreshHandler.cs           # Nutzt RefreshAuthHttpRequest (OpenAPI)
│       ├── SignOutHandler.cs
│       └── GetAuthStateHandler.cs
└── Presentation/
    ├── LoginPage.xaml
    ├── LoginPage.xaml.cs
    └── LoginViewModel.cs
```

## OpenAPI HTTP Contract Generation

Die Handler nutzen automatisch generierte HTTP-Contracts aus der API OpenAPI-Spezifikation:

- `SignInHandler` → `SignInHttpRequest` (generiert aus `/auth/signin/mobile`)
- `RefreshHandler` → `RefreshAuthHttpRequest` (generiert aus `/auth/signin/refresh`)

Die Contracts werden in `Core.Startup.csproj` konfiguriert und zur Build-Zeit generiert.

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

- `AIRoutine.FullStack.Features.Auth.Contracts` - Request/Response DTOs
- `UnoFramework` - BaseServices, PageViewModel
- `Uno.Extensions.Storage` - IKeyValueStorage
- `System.Net.Http` - HttpClient

## Verwendung

### Feature registrieren

In `Core.Startup/ServiceCollectionExtensions.cs`:

```csharp
services.AddAuthFeature();
```

### Navigation zur Login-Page

```csharp
// Von ViewModel
await Navigator.NavigateRouteAsync(this, "/Login");
```

### Auth-Status prüfen

```csharp
var authState = await Mediator.Request(new GetAuthStateRequest());
if (!authState.IsAuthenticated)
{
    // Zur Login-Page navigieren
}
```

### Sign-In durchführen

```csharp
var response = await Mediator.Request(new SignInRequest("Microsoft"));
if (response.Success)
{
    // Navigation zur Hauptseite
}
```

### Sign-Out durchführen

```csharp
await Mediator.Send(new SignOutCommand());
```
