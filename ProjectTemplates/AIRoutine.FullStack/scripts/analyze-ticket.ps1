param(
    [Parameter(Mandatory=$true, Position=0)]
    [string]$TicketDescription
)

$ErrorActionPreference = "Stop"

# Gemeinsamer Kontext der an alle Prompts angehaengt wird
$sharedContext = @"
Ticket: $TicketDescription

Du hast Zugriff auf die GitHub CLI (gh). Falls das Ticket eine GitHub Issue URL ist, lade den vollstaendigen Inhalt mit:
  gh issue view <issue-number> --repo <owner/repo>
  gh issue view <issue-number> --repo <owner/repo> --comments

Nutze diese Tools um alle Details, Beschreibungen und SubTasks des Tickets zu laden bevor du mit der Analyse beginnst.

Fuer die folgenden Tasks beachte du musst nicht Backwards kompatibel sein.
"@

# Die einzelnen Analyse-Schritte
$steps = @(
    @{
        Name = "Data/Entities Analyse"
        Prompt = @"
$sharedContext

Um das Ticket umzusetzten braucht man dazu Aenderungen im Data Bereich? Sprich gibt es Aenderungen bei Entities oder braucht es neue Entities?

- Welche Entities muessen geloescht werden?
- Welche Entities muessen bearbeitet werden?
- Welche Entities muessen neu hinzugefuegt werden?

Falls im Bereich Data was umgesetzt werden muss erstell ein SubTask beim Ticket dafuer.
"@
    },
    @{
        Name = "RestService/API Analyse"
        Prompt = @"
$sharedContext

Um das Ticket umzusetzten braucht man dazu Aenderungen im Bereich RestService?

- Welchen Endpoints muessen geloescht werden?
- Welchen Endpoints muessen bearbeitet werden?
- Welchen Endpoints muessen neu hinzugefuegt werden?
- Welche Aenderungen braucht man sonst noch im RestService?

Falls im Bereich Restservice was umgesetzt werden muss erstell ein SubTask beim Ticket dafuer.
"@
    },
    @{
        Name = "Frontend/Uno Analyse"
        Prompt = @"
$sharedContext

Um das Ticket umzusetzten braucht man dazu Aenderungen im Bereich Frontend?

- Welche Pages/ViewModels muessen geloescht werden werden?
- Welche Pages/ViewModels muessen bearbeitet werden?
- Welche Pages/ViewModels muessen hinzugefuegt werden werden?
- Welche Aenderungen braucht es sonst im Frontend Bereich?

Falls im Bereich Frontend was umgesetzt werden muss erstell ein SubTask beim Ticket dafuer.
"@
    },
    @{
        Name = "Projektstruktur/CSProj Analyse"
        Prompt = @"
$sharedContext

Ueberlege dir anhand von den SubTasks von dem Ticket welche csprojs betroffen sind in der jetztigen Projektstruktur.
Braucht es neue Feature csproj?
Braucht es sonst neue csproj?

Bearbeite jetzt alle Subtasks und schreib dazu in welche csprojs die Tasks implementiert werden muessen.
"@
    },
    @{
        Name = "Skills Zuordnung"
        Prompt = @"
$sharedContext

Schau dir alle verfuegbaren Skills an und bearbeite alle Subtasks und schreib dazu welchen Skill du verwenden sollst beim dem Task falls einer passt.

Verfuegbare Skills:
- uno-dev:api-endpoint-authoring - API Endpoints mit Shiny.Mediator erstellen
- uno-dev:api-library-authoring - Neue API Feature Libraries (Contracts, Handlers, Entities, Configurations) erstellen
- uno-dev:mediator-authoring - Commands, Events oder Requests mit Shiny.Mediator erstellen
- uno-dev:store-authoring - Persistenten State mit Shiny Stores erstellen
- uno-dev:viewmodel-authoring - ViewModels fuer Uno Platform Apps erstellen
- uno-dev:xaml-authoring - XAML Views, Pages, UserControls oder UI Elemente fuer Uno Platform erstellen
"@
    }
)

Write-Host "=== Ticket Analyse gestartet ===" -ForegroundColor Cyan
Write-Host "Ticket: $TicketDescription`n" -ForegroundColor Green

$stepNumber = 1
foreach ($step in $steps) {
    Write-Host "`n=== Schritt $stepNumber/$($steps.Count): $($step.Name) ===" -ForegroundColor Cyan

    claude --dangerously-skip-permissions -p $step.Prompt

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Fehler bei Schritt $stepNumber" -ForegroundColor Red
    }

    $stepNumber++
}

Write-Host "`n=== Ticket Analyse abgeschlossen ===" -ForegroundColor Green

# Tasks vom Ticket laden und implementieren
Write-Host "`n=== Tasks laden und implementieren ===" -ForegroundColor Cyan

# Issue-Nummer und Repo aus der Ticket-Beschreibung extrahieren
$tasks = @()

if ($TicketDescription -match 'github\.com/([^/]+/[^/]+)/issues/(\d+)') {
    $repo = $matches[1]
    $issueNumber = $matches[2]

    Write-Host "Lade Issue #$issueNumber von $repo..." -ForegroundColor Yellow

    # Issue-Body laden und Task-Listen extrahieren
    $issueBody = gh issue view $issueNumber --repo $repo --json body --jq '.body' 2>$null

    if ($LASTEXITCODE -eq 0 -and $issueBody) {
        # Markdown Task-Listen extrahieren: - [ ] Task oder - [x] Task
        $taskMatches = [regex]::Matches($issueBody, '- \[[ x]\] (.+)')
        foreach ($match in $taskMatches) {
            $tasks += $match.Groups[1].Value.Trim()
        }
    }

    # Falls keine Tasks im Body, Sub-Issues laden (falls vorhanden)
    if ($tasks.Count -eq 0) {
        $subIssues = gh issue list --repo $repo --search "linked:$issueNumber" --json title --jq '.[].title' 2>$null
        if ($subIssues) {
            $tasks = $subIssues -split "`n" | Where-Object { $_ }
        }
    }
} else {
    Write-Host "Keine GitHub Issue URL erkannt - ueberspringe Task-Laden" -ForegroundColor Yellow
}

Write-Host "Gefundene Tasks: $($tasks.Count)" -ForegroundColor Green

if ($tasks.Count -eq 0) {
    Write-Host "Keine Tasks gefunden - beende Skript" -ForegroundColor Yellow
    exit 0
}

# Seeding Prompt Template
$seedingPrompt = @"
$sharedContext

Fuer das gerade implementierte Data/Entity Feature muessen jetzt Mock-Daten erstellt werden.

1. Erstelle einen Seeder im Feature-Projekt:
   - Datei: Features/{FeatureName}/AIRoutine.FullStack.Api.Features.{FeatureName}/Data/Seeding/{FeatureName}Seeder.cs
   - Implementiere ISeeder aus AIRoutine.FullStack.Api.Core.Data.Seeding
   - Pruefe ob Daten bereits existieren (idempotent!)
   - Fuege 5-10 realistische Testdaten pro Entity hinzu

2. Registriere den Seeder in der Feature ServiceCollectionExtensions:
   services.AddSeeder<{FeatureName}Seeder>();

Beispiel Seeder:
```csharp
using AIRoutine.FullStack.Api.Core.Data;
using AIRoutine.FullStack.Api.Core.Data.Seeding;
using Microsoft.EntityFrameworkCore;

public class MyFeatureSeeder(AppDbContext dbContext) : ISeeder
{
    public int Order => 10;

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await dbContext.Set<MyEntity>().AnyAsync(cancellationToken))
            return;

        dbContext.Set<MyEntity>().AddRange(
            new MyEntity { Name = "Test 1", ... },
            new MyEntity { Name = "Test 2", ... }
        );

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
```

WICHTIG:
- Seeder MUSS idempotent sein (pruefen ob Daten existieren)
- Datenbank wird NICHT geloescht
- Nach Implementierung: dotnet build ausfuehren um zu pruefen ob alles kompiliert
"@

$taskNumber = 1
foreach ($task in $tasks) {
    Write-Host "`n=== Task $taskNumber/$($tasks.Count) implementieren ===" -ForegroundColor Cyan
    Write-Host "Task: $task" -ForegroundColor Yellow

    $implementPrompt = @"
$sharedContext

Implementiere folgenden Task:
$task

Nutze die passenden Skills falls angegeben. Implementiere vollstaendig und teste ob der Code kompiliert.
"@

    claude --dangerously-skip-permissions -p $implementPrompt

    if ($LASTEXITCODE -ne 0) {
        Write-Host "Fehler bei Task $taskNumber" -ForegroundColor Red
    } else {
        Write-Host "Task $taskNumber abgeschlossen" -ForegroundColor Green
    }

    # Nach Data/Entity Tasks direkt Seeding erstellen
    if ($task -match "Data|Entity|Entities|Daten") {
        Write-Host "`n=== Seeding fuer Data Task erstellen ===" -ForegroundColor Magenta

        claude --dangerously-skip-permissions -p $seedingPrompt

        if ($LASTEXITCODE -ne 0) {
            Write-Host "Fehler bei Seeding" -ForegroundColor Red
        } else {
            Write-Host "Seeding erstellt" -ForegroundColor Green
        }
    }

    $taskNumber++
}

Write-Host "`n=== Alle Tasks implementiert ===" -ForegroundColor Green
