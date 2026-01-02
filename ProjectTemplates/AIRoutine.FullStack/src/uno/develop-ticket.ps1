param(
    [Parameter(Mandatory=$true, Position=0)]
    [string]$TicketDescription
)

$ErrorActionPreference = "Stop"

Write-Host "=== Schritt 1: Git Commit vor Ticket ===" -ForegroundColor Cyan
git add .
git commit -m "Vor ticket" 2>$null
if ($LASTEXITCODE -ne 0) {
    Write-Host "Keine Aenderungen zum Committen oder Commit fehlgeschlagen" -ForegroundColor Yellow
}

Write-Host "`n=== Schritt 2: Entwicklung mit Claude ===" -ForegroundColor Cyan
Write-Host "Ticket: $TicketDescription" -ForegroundColor Green
claude --dangerously-skip-permissions -p "/uno-dev:develop $TicketDescription"

Write-Host "`n=== Schritt 3: UI/UX Design Review ===" -ForegroundColor Cyan
$designReviewPrompt = @"
Wenn es Aenderungen im Frontend gab, geh mit uno app mcp die Aenderungen durch und schau ob sie ein sehr schoenes schlichtes Design haben. Falls dir im UI/UX Design was auffaellt zum Verbessern, verbessere es.
"@
claude --dangerously-skip-permissions -p $designReviewPrompt

Write-Host "`n=== Schritt 4: Testen mit Uno App MCP ===" -ForegroundColor Cyan
$testPrompt = @"
Teste die aktuellen Aenderungen mit uno app mcp und teste ob alles perfekt funktioniert.
"@
claude --dangerously-skip-permissions -p $testPrompt

Write-Host "`n=== Fertig ===" -ForegroundColor Green
