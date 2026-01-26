# AIRoutine.FullStack

## Technische Details

- **Sprache:** C# latest
- **Framework:** .NET 10
- **Frontend:** Uno Platform (nutze Uno MCP und definierte Skills)
- **Backend:** ASP.NET (nutze Microsoft Docs MCP und definierte Skills)
- **Architektur:** Shiny Mediator Pattern ([GitHub](https://github.com/shinyorg/mediator))

## Architekturprinzip: Backend-First

**Alle Logik im Backend. Frontend nur für Anzeige.**

| Backend (API) | Frontend (Uno) |
|---------------|----------------|
| Geschäftslogik, Validierung, Berechnungen | UI, Navigation, API-Aufrufe |
| Datenbank, Security, externe Services | Loading-States, UX-Feedback |

## Projektstruktur (Kurzübersicht)

```
AIRoutine.FullStack/
├── src/
│   ├── api/                        # Backend (ASP.NET)
│   │   └── src/
│   │       ├── *.Api/              # Host
│   │       ├── Core/               # DbContext, Startup
│   │       └── Features/{Name}/    # Feature-Module
│   │
│   └── uno/                        # Frontend (Uno Platform)
│       └── src/
│           ├── *.App/              # Hauptprojekt
│           ├── Core/               # Startup, Styles
│           └── Features/{Name}/    # Feature-Module
│
└── subm/uno/                       # UnoFramework Submodule
```

> `*` = `AIRoutine.FullStack` Namespace-Prefix

## Dokumentation

Detaillierte Anleitungen sind in modularen Rules unter `.claude/rules/` organisiert:

- **Dependency Injection:** `.claude/rules/dependency-injection.md`
- **Projektstruktur:** `.claude/rules/project-structure.md`
- **API Features:** `.claude/rules/api/features.md`
- **API Mediator Endpoints:** `.claude/rules/api/mediator-endpoints.md`
- **API Datenbank:** `.claude/rules/api/database.md`
- **Uno Features:** `.claude/rules/uno/features.md`

Die API- und Uno-spezifischen Rules werden automatisch geladen wenn in den entsprechenden Verzeichnissen gearbeitet wird.
