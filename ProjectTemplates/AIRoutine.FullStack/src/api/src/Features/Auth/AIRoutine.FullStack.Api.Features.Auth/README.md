# AIRoutine.FullStack.Api.Features.Auth

Authentifizierungs-Feature mit JWT-basierter Benutzerauthentifizierung.

## Zweck

- Benutzer- und Token-Verwaltung
- JWT-Token Generierung und Validierung
- Refresh-Token Unterstützung
- Entity Framework Konfigurationen für Auth-Entities

## Struktur

```
Auth/
├── Configuration/
│   └── ServiceCollectionExtensions.cs  # AddAuthFeature()
├── Data/
│   ├── Entities/
│   │   ├── User.cs                     # Benutzer-Entity
│   │   └── RefreshToken.cs             # Refresh-Token Entity
│   └── Configurations/
│       ├── UserConfiguration.cs
│       └── RefreshTokenConfiguration.cs
└── Services/
    ├── IUserService.cs                 # Aktueller Benutzer
    ├── UserService.cs
    └── JwtService.cs                   # JWT Generierung
```

## Öffentliche APIs

### IUserService

```csharp
public interface IUserService
{
    Guid UserId { get; }
}
```

### JwtService

JWT-Token Generierung und Validierung.

### ServiceCollectionExtensions

```csharp
services.AddAuthFeature();
```

## Abhängigkeiten

- `AIRoutine.FullStack.Api.Core.Data` - BaseEntity, AppDbContext
- `AIRoutine.FullStack.Api.Features.Auth.Contracts` - Request/Response DTOs

## Entities

### User

Benutzer-Entity mit Authentifizierungsdaten.

### RefreshToken

Refresh-Token für Token-Erneuerung.
