# AIRoutine.FullStack Mobile

## Technische Details

- **Sprache:** C# latest
- **Framework:** .NET 10
- **Frontend:** Uno Platform (nutze Uno MCP und definierte Skills)
- **Backend:** ASP.NET (nutze Microsoft Docs MCP und definierte Skills)
- **Architektur:** Shiny Mediator Pattern ([GitHub](https://github.com/shinyorg/mediator))

## Projektstruktur

Jedes Feature besteht aus zwei Projekten:
1. **Hauptprojekt** - Implementierungen
2. **Contracts-Projekt** - Interfaces und Mediator-Contracts

### Namenskonventionen

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `Features/` | `AIRoutine.FullStack.Features.FeatureName` |
| Core Features | `Core/` | `AIRoutine.FullStack.Core.FeatureName` |
| Third Party | `ThirdParty/` | `AIRoutine.FullStack.ThirdParty.FeatureName` |

### Contracts-Projekt

> Enthält: Interfaces vom Hauptprojekt, Shiny Mediator Contracts

```
AIRoutine.FullStack.Features.{FeatureName}.Contracts/
├── Models/                       # Data Transfer Objects
├── Enums/                        # Shared Enumerations
├── Interfaces/                   # Service-Interfaces
└── Mediator/
    ├── Commands/                 # Command-Contracts (ICommand)
    ├── Requests/                 # Request-Contracts (IRequest<TResult>)
    ├── Events/                   # Event-Contracts (IEvent)
    └── Navigations/              # Navigation-Contracts
```

### Hauptprojekt

```
AIRoutine.FullStack.Features.{FeatureName}/
├── Configuration/                # DI Setup, Extensions, Registrierung
├── Domain/                       # Entities, Value Objects, Aggregates
├── Mediator/
│   ├── Commands/                 # Command-Handler
│   ├── Requests/                 # Request-Handler
│   ├── Events/                   # Event-Handler
│   └── Middlewares/              # Mediator-Middlewares
└── Presentation/                 # UI Vertical Slices
    └── {Bereich}/
        ├── {Bereich}ViewModel.cs
        └── {Bereich}Page.xaml
```
