# AIRoutine.FullStack.Api.Features.Auth.Handlers

Mediator-Handler für die Authentifizierungs-Requests.

## Zweck

- Implementierung der Business-Logik für Auth-Requests
- Verarbeitung von SignIn, Refresh und SignOut Operationen
- Nutzung der Auth-Services für Token-Management

## Struktur

```
Handlers/
├── SignInHandler.cs     # Verarbeitet SignInRequest
├── RefreshHandler.cs    # Verarbeitet RefreshRequest
└── SignOutHandler.cs    # Verarbeitet SignOutCommand
```

## Handlers

### SignInHandler

Verarbeitet `SignInRequest` und initiiert den Authentifizierungsflow.

```csharp
public class SignInHandler : IRequestHandler<SignInRequest, SignInResponse>
```

### RefreshHandler

Verarbeitet `RefreshRequest` und erneuert JWT-Tokens.

```csharp
public class RefreshHandler : IRequestHandler<RefreshRequest, RefreshResponse>
```

### SignOutHandler

Verarbeitet `SignOutCommand` und invalidiert Tokens.

```csharp
public class SignOutHandler : ICommandHandler<SignOutCommand>
```

## Abhängigkeiten

- `AIRoutine.FullStack.Api.Features.Auth` - Services (JwtService, IUserService)
- `AIRoutine.FullStack.Api.Features.Auth.Contracts` - Request/Response DTOs
- `AIRoutine.FullStack.Api.Core.Data` - AppDbContext
- Shiny.Mediator - Handler Interfaces
