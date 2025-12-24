# AIRoutine.UnoApp

## Technische Details

- **Sprache:** C# latest
- **Framework:** .NET 10
- **Frontend:** Uno Platform (nutze Uno MCP und definierte Skills)
- **Architektur:** Shiny Mediator Pattern ([GitHub](https://github.com/shinyorg/mediator))

## Aktuelle Projektstruktur

```
AIRoutine.UnoApp/
├── .claude/
│   └── settings.json                           # Claude Code Einstellungen
├── .gitignore
├── .gitmodules
├── Claude.md                                   # Diese Datei
├── Directory.Build.props                       # Zentrale Build-Eigenschaften
├── Directory.Packages.props                    # Zentrale Package-Versionen
├── global.json                                 # .NET SDK Version
├── AIRoutine.UnoApp.slnx                       # Solution-Datei
│
├── src/
│   ├── AIRoutine.UnoApp.App/                   # Hauptprojekt (Executable)
│   │   ├── AIRoutine.UnoApp.App.csproj
│   │   ├── App.xaml                            # Application Entry
│   │   ├── App.xaml.cs
│   │   ├── GlobalUsings.cs
│   │   ├── appsettings.json
│   │   ├── appsettings.development.json
│   │   ├── Models/
│   │   │   └── AppConfig.cs
│   │   ├── Presentation/
│   │   │   ├── Shell.xaml
│   │   │   ├── Shell.xaml.cs
│   │   │   ├── ShellViewModel.cs
│   │   │   ├── MainPage.xaml
│   │   │   ├── MainPage.xaml.cs
│   │   │   └── MainViewModel.cs
│   │   └── Platforms/
│   │       ├── Android/
│   │       ├── iOS/
│   │       ├── Desktop/
│   │       └── WebAssembly/
│   │
│   └── Core/
│       └── AIRoutine.UnoApp.Core.Startup/      # DI Setup & Konfiguration
│           ├── AIRoutine.UnoApp.Core.Startup.csproj
│           └── ServiceCollectionExtensions.cs  # AddAppServices()
│
└── subm/
    └── uno/                                    # UnoFramework Submodule
```

## Feature-Erweiterungsstruktur

Bei neuen Features erstelle zwei Projekte:
1. **Hauptprojekt** - Implementierungen
2. **Contracts-Projekt** - Interfaces und Mediator-Contracts

### Namenskonventionen

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/Features/` | `AIRoutine.UnoApp.Features.FeatureName` |
| Core Features | `src/Core/` | `AIRoutine.UnoApp.Core.FeatureName` |
| Third Party | `src/ThirdParty/` | `AIRoutine.UnoApp.ThirdParty.FeatureName` |

### Contracts-Projekt

```
src/Features/AIRoutine.UnoApp.Features.{FeatureName}.Contracts/
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
src/Features/AIRoutine.UnoApp.Features.{FeatureName}/
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
