---
paths:
  - "src/api/**"
---

# Shiny.Mediator HTTP Endpoints

API-Handler mit automatischer OpenAPI-Generierung und Endpoint-Registrierung.

## Package Requirements

```xml
<ItemGroup>
  <FrameworkReference Include="Microsoft.AspNetCore.App" />
  <PackageReference Include="Shiny.Mediator.AspNet" />
</ItemGroup>
```

## Handler mit MediatorHttpGet

```csharp
using AIRoutine.FullStack.Api;
using Shiny.Extensions.DependencyInjection;
using Shiny.Mediator;

[Service(ApiService.Lifetime, TryAdd = ApiService.TryAdd)]
public class GetItemsHandler(AppDbContext dbContext) : IRequestHandler<GetItemsRequest, GetItemsResponse>
{
    [MediatorHttpGet("/api/items", OperationId = "GetItems")]
    public async Task<GetItemsResponse> Handle(GetItemsRequest request, IMediatorContext context, CancellationToken cancellationToken)
    {
        // Implementation
    }
}
```

## Endpoint Registrierung

```csharp
// In Core.Startup/ServiceCollectionExtensions.cs
public static WebApplication MapEndpoints(this WebApplication app)
{
    app.MapGeneratedMediatorEndpoints(); // Aufruf triggert Source Generator
    return app;
}
```

## WICHTIG - Response Types

- NIEMALS nullable Response Types verwenden (`IRequest<ItemDto?>`)
- IMMER Wrapper Response Record verwenden:

```csharp
// FALSCH:
public record GetItemByIdRequest(Guid Id) : IRequest<ItemDto?>;

// RICHTIG:
public record GetItemByIdRequest(Guid Id) : IRequest<GetItemByIdResponse>;
public record GetItemByIdResponse(ItemDto? Item);
```

## API Enum Best Practices

Enums MUESSEN mit `JsonStringEnumConverter` annotiert werden fuer korrekte OpenAPI-Generierung:

```csharp
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemType
{
    TypeA = 1,
    TypeB = 2
}
```

Dies stellt sicher, dass:
- OpenAPI Schema die Enum-Werte als Strings enthaelt
- Der MediatorHttp Source Generator die Enums korrekt generiert
- Der Uno ApiClient die Enum-Typen erhaelt
