# AIRoutine.FullStack.Api.Features.Auth.Contracts

Mediator-Contracts (Request/Response DTOs) für das Auth-Feature.

## Zweck

- Definition der Mediator Request/Response Typen
- Schnittstelle zwischen API-Endpoints und Handlers
- Shared zwischen API und potenziellen Clients

## Struktur

```
Contracts/
└── Mediator/
    └── Requests/
        ├── SignInRequest.cs
        ├── RefreshRequest.cs
        └── SignOutCommand.cs
```

## Requests

### SignInRequest

Initiiert den Anmeldeprozess mit einem Auth-Schema.

```csharp
public record SignInRequest(string Scheme) : IRequest<SignInResponse>;

public record SignInResponse(bool Success, string? Uri = null);
```

### RefreshRequest

Erneuert JWT mittels Refresh-Token.

```csharp
public record RefreshRequest(string Token) : IRequest<RefreshResponse>;

public record RefreshResponse(bool Success, string? Jwt, string? RefreshToken);
```

### SignOutCommand

Meldet den Benutzer ab und invalidiert Tokens.

```csharp
public record SignOutCommand(string RefreshToken, string? PushToken) : ICommand;
```

## Abhängigkeiten

- Shiny.Mediator.Contracts - IRequest, ICommand Interfaces
