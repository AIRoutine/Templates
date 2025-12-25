# AIRoutine.FullStack.Features.Auth

Authentifizierungs-Feature für die Uno Platform App mit JWT-basierter Benutzerauthentifizierung.

## Zweck

- Token-Management (JWT und Refresh-Token)
- Secure Storage für Authentifizierungsdaten
- API-Client für Auth-Endpoints
- Mediator-Handler für Auth-Operationen
- Login-UI (Page und ViewModel)

## Struktur

```
Auth/
├── Configuration/
│   └── ServiceCollectionExtensions.cs  # AddAuthFeature()
├── Services/
│   ├── IAuthService.cs                 # Token-Management Interface
│   ├── AuthService.cs                  # Secure Storage Implementation
│   ├── IAuthApiClient.cs               # API Client Interface
│   └── AuthApiClient.cs                # HttpClient Implementation
├── Mediator/
│   └── Requests/
│       ├── SignInHandler.cs
│       ├── RefreshHandler.cs
│       ├── SignOutHandler.cs
│       └── GetAuthStateHandler.cs
└── Presentation/
    ├── LoginPage.xaml
    ├── LoginPage.xaml.cs
    └── LoginViewModel.cs
```

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

### IAuthApiClient

```csharp
public interface IAuthApiClient
{
    Task<ApiSignInResponse> SignInAsync(string scheme, CancellationToken ct = default);
    Task<ApiRefreshResponse> RefreshAsync(string refreshToken, CancellationToken ct = default);
    Task SignOutAsync(string refreshToken, string? pushToken = null, CancellationToken ct = default);
}
```

### ServiceCollectionExtensions

```csharp
// Einfache Registrierung
services.AddAuthFeature();

// Mit konfigurierter API-Adresse
services.AddAuthFeature("https://api.example.com");
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
