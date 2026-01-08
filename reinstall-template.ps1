#!/usr/bin/env pwsh
# Reinstall AIRoutine.FullStack Template

$templatePath = Join-Path $PSScriptRoot "ProjectTemplates\AIRoutine.FullStack"

try {
    Write-Host "Deinstalliere Template..." -ForegroundColor Yellow
    dotnet new uninstall $templatePath 2>$null

    Write-Host "Installiere Template..." -ForegroundColor Green
    dotnet new install $templatePath

    Write-Host "`nTemplate erfolgreich neu installiert!" -ForegroundColor Cyan
    Write-Host "Verwendung: dotnet new airoutine-fullstack -n MeinProjekt" -ForegroundColor Gray
}
catch {
    Write-Host "`nFehler: $_" -ForegroundColor Red
}
finally {
    Read-Host "`nDruecke Enter zum Beenden"
}
