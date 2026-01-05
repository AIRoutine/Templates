using Shiny.Mediator;

namespace AIRoutine.FullStack.Cli.Contracts.Requests;

/// <summary>
/// Step 7: Tasks implementieren
/// </summary>
public record ImplementTasksRequest(StepContext Context, List<string> Tasks) : IRequest<StepResult>;
