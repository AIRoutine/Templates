param(
    [Parameter(Mandatory=$true, Position=0)]
    [string]$TicketDescription
)

$ErrorActionPreference = "Stop"

# Gemeinsamer Kontext der an alle Prompts angehaengt wird
$sharedContext = @"
Ticket: $TicketDescription

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
