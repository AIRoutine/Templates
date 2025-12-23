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
| AIRoutine Full-Stack | `airoutine-fullstack` | Combined API + Uno App with shared configuration |

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

### Create a Full-Stack Project (API + Uno App)

```bash
dotnet new airoutine-fullstack -n MyProject
cd MyProject
git submodule update --init --recursive
dotnet build
```

## Full-Stack Template Structure

The `airoutine-fullstack` template creates a unified project with shared configuration:

```
MyProject/
├── src/
│   ├── api/                    # ASP.NET API
│   │   ├── Directory.Build.props   (inherits from root)
│   │   ├── Directory.Packages.props (inherits from root)
│   │   └── src/
│   │       ├── MyProject.Api/
│   │       ├── MyProject.Api.Contracts/
│   │       └── MyProject.Api.Handlers/
│   │
│   └── unoapp/                 # Uno Platform App
│       ├── Directory.Build.props   (inherits from root)
│       ├── Directory.Packages.props (inherits from root)
│       ├── global.json
│       └── src/host/MyProject.App/
│
├── framework/                  # UnoFramework (git submodule)
├── Directory.Build.props       # Root - defines NetVersion
├── Directory.Packages.props    # Root - central package versions
└── MyProject.slnx
```

### Inheritance Hierarchy

```
Root Directory.Build.props (NetVersion = net10.0)
  ↓ Inherited by
  ├── src/api/Directory.Build.props
  └── src/unoapp/Directory.Build.props

Root Directory.Packages.props (all package versions)
  ↓ Inherited by
  ├── src/api/Directory.Packages.props
  └── src/unoapp/Directory.Packages.props
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
