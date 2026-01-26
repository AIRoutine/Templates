# Projektstruktur

```
AIRoutine.FullStack/
├── src/
│   ├── api/                        # Backend (ASP.NET)
│   │   └── src/
│   │       ├── *.Api/                             # Host
│   │       ├── *.Api.Contracts/                   # Globale DTOs
│   │       ├── *.Api.Handlers/                    # Globale Handler
│   │       ├── Shared/
│   │       │   └── *.Api.Shared/                  # ApiService DI-Konstanten
│   │       ├── Core/
│   │       │   ├── *.Api.Core.Data/               # DbContext, BaseEntity
│   │       │   └── *.Api.Core.Startup/            # DI Setup
│   │       └── Features/{Name}/
│   │           ├── *.Api.Features.{Name}/         # Services, Data, Handlers
│   │           └── *.Api.Features.{Name}.Contracts/
│   │
│   └── uno/                        # Frontend (Uno Platform)
│       └── src/
│           ├── *.App/                             # Hauptprojekt
│           ├── Shared/
│           │   └── *.Shared/                      # UnoService DI-Konstanten
│           ├── Core/
│           │   ├── *.Core.Startup/                # DI Setup
│           │   └── *.Core.Styles/                 # Design System
│           └── Features/{Name}/
│               ├── *.Features.{Name}/             # Services, Presentation
│               └── *.Features.{Name}.Contracts/
│
└── subm/uno/                       # UnoFramework Submodule
```

> `*` = `AIRoutine.FullStack` Namespace-Prefix

## Namenskonventionen

### API

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/api/src/Features/` | `AIRoutine.FullStack.Api.Features.{FeatureName}` |
| Core Features | `src/api/src/Core/` | `AIRoutine.FullStack.Api.Core.{FeatureName}` |

### Uno

| Typ | Ordner | Benennung |
|-----|--------|-----------|
| Features | `src/uno/src/Features/` | `AIRoutine.FullStack.Features.FeatureName` |
| Core Features | `src/uno/src/Core/` | `AIRoutine.FullStack.Core.FeatureName` |
| Third Party | `src/uno/src/ThirdParty/` | `AIRoutine.FullStack.ThirdParty.FeatureName` |

## Projektdokumentation

**Jedes Projekt (Core, Features, ThirdParty) MUSS eine `README.md` Datei im Projektstammverzeichnis enthalten.**

Die README.md dokumentiert:
- Zweck und Verantwortlichkeiten des Projekts
- Öffentliche APIs und Services
- Abhängigkeiten zu anderen Projekten
- Konfigurationsoptionen (falls vorhanden)
- Beispiele zur Verwendung
