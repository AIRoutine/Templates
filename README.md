# AIRoutine.Templates

Project templates for AIRoutine ASP.NET API and Uno Platform applications.

## Installation

```bash
dotnet new install AIRoutine.Templates
```

## Available Templates

| Template | Short Name | Description |
|----------|------------|-------------|
| AIRoutine ASP.NET API | `airoutine-api` | ASP.NET Core API with Shiny.Mediator (CQRS pattern) |
| AIRoutine Uno App | `airoutine-uno` | Uno Platform app with UnoFramework integration |

## Usage

### Create an ASP.NET API Project

```bash
dotnet new airoutine-api -n MyApi
cd MyApi
dotnet build
```

### Create an Uno Platform Project

```bash
dotnet new airoutine-uno -n MyApp
cd MyApp
git submodule update --init --recursive
dotnet build
```

## ASP.NET API Template Features

- 3-tier CQRS architecture (API, Contracts, Handlers)
- Shiny.Mediator for request/response handling
- OpenAPI + Scalar documentation
- .NET 10 with central package management
- AIRoutine.CodeStyle analyzers

## Uno Platform Template Features

- Multi-target: Android, iOS, WebAssembly, Desktop
- UnoFramework integration (via Git submodule)
- MVVM with CommunityToolkit.Mvvm
- Shiny.Mediator for event handling
- Built-in busy indicators and navigation

## Uninstallation

```bash
dotnet new uninstall AIRoutine.Templates
```

## License

MIT
