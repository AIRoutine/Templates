---
paths:
  - "src/api/src/**"
---

# Shiny.Mediator HTTP Endpoints

**Nutze den Shiny Mediator MCP für die Erstellung von API-Endpunkten.**

Der MCP bietet aktuelle Dokumentation und Beispiele für:
- Handler mit `MediatorHttpGet`, `MediatorHttpPost`, etc.
- Request/Response Records
- Endpoint-Registrierung
- OpenAPI-Generierung

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

Enums MUESSEN mit `[JsonConverter(typeof(JsonStringEnumConverter))]` annotiert werden fuer korrekte OpenAPI-Generierung und Uno ApiClient Enum-Typen.
