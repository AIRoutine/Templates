# AIRoutine.FullStack.Core.ApiClient

API-Client-Bibliothek für die Kommunikation mit dem Backend via Shiny.Mediator HTTP Extension.

## Zweck

Dieses Projekt generiert automatisch HTTP-Contracts aus der OpenAPI-Spezifikation des Backends und stellt diese für alle Uno-Features bereit.

## Funktionsweise

### OpenAPI Contract Generation

Die Contracts werden zur Build-Zeit aus der generierten OpenAPI-Datei des Backend-Projekts generiert:

```xml
<MediatorHttp Include="$(ApiOpenApiFile)"
              Namespace="AIRoutine.FullStack.Core.ApiClient.Generated"
              ContractPostfix="HttpRequest"
              GenerateJsonConverters="false"
              Visible="false" />
```

**Setup:**
1. Das API-Projekt generiert automatisch `openapi.json` beim Build
2. Diese Datei wird in `src/api/Generated/` gespeichert
3. Der ApiClient referenziert diese Datei zur Contract-Generierung

**Wichtig:** Bei einem Fresh Clone muss zuerst das API-Projekt gebaut werden:
```bash
cd src/api/src/AIRoutine.FullStack.Api
dotnet build
```

Danach kann das Uno-Projekt gebaut werden. Falls die `openapi.json` fehlt, erscheint eine klare Fehlermeldung mit Anweisungen.

### Verwendung in Features

```csharp
// Inject IMediator
public class MyViewModel(IMediator mediator)
{
    public async Task LoadData()
    {
        var response = await mediator.Request(new GetDataHttpRequest());
    }
}
```

### Handler-Registrierung

**Wichtig:** Die generierten HTTP-Handler müssen explizit registriert werden:

```csharp
// In ServiceCollectionExtensions.cs
public static IServiceCollection AddApiClientFeature(this IServiceCollection services)
{
    services.AddGeneratedOpenApiClient(); // Generiert vom Source Generator
    return services;
}
```

Ohne diesen Aufruf: `No request handler found for XxxHttpRequest`

### Konfiguration

Base-URL in `appsettings.json`:

```json
{
  "Mediator": {
    "Http": {
      "AIRoutine.FullStack.Core.ApiClient.Generated.*": "http://localhost:5292"
    }
  }
}
```

## Abhängigkeiten

- `Shiny.Mediator` - Mediator Pattern Implementation
- `Shiny.Mediator.Http` - HTTP Extension für automatische Request-Handling

## Referenzen

- [Shiny.Mediator HTTP Extension](https://shinylib.net/mediator/extensions/http/)
- [Shiny.Mediator GitHub](https://github.com/shinyorg/mediator)
