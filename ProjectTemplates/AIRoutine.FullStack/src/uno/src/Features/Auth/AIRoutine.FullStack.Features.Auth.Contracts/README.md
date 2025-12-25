# AIRoutine.FullStack.Features.Auth.Contracts

Mediator-Contracts (Request/Response DTOs) für das Auth-Feature auf der Client-Seite.

## Zweck

- Definition der Mediator Request/Response Typen
- Schnittstelle zwischen UI und Auth-Handlers
- Shared zwischen verschiedenen App-Komponenten

## Struktur

```
Contracts/
└── Mediator/
    └── Requests/
        ├── SignInRequest.cs
        ├── RefreshRequest.cs
        ├── SignOutCommand.cs
        └── GetAuthStateRequest.cs
```

## Requests

### SignInRequest

Initiiert den Anmeldeprozess mit einem Auth-Schema.

```csharp
public record SignInRequest(string Scheme) : IRequest<SignInResponse>;

public record SignInResponse(bool Success, string? ErrorMessage = null);
```

### RefreshRequest

Erneuert die Authentifizierungs-Tokens.

```csharp
public record RefreshRequest : IRequest<RefreshResponse>;

public record RefreshResponse(bool Success, string? ErrorMessage = null);
```

### SignOutCommand

Meldet den Benutzer ab.

```csharp
public record SignOutCommand : ICommand;
```

### GetAuthStateRequest

Ruft den aktuellen Authentifizierungsstatus ab.

```csharp
public record GetAuthStateRequest : IRequest<AuthState>;

public record AuthState(bool IsAuthenticated, string? UserEmail = null, string? DisplayName = null);
```

## Abhängigkeiten

- Shiny.Mediator - IRequest, ICommand Interfaces
