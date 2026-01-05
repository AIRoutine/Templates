using Shiny.Mediator;

namespace AIRoutine.FullStack.Cli.Contracts.Requests;

/// <summary>
/// Nur Analyse (Steps 1-5), ohne Implementierung
/// </summary>
public record AnalyzeOnlyRequest(StepContext Context) : IRequest<StepResult>;
