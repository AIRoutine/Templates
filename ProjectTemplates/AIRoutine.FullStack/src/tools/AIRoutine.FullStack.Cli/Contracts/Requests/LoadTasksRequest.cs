using Shiny.Mediator;

namespace AIRoutine.FullStack.Cli.Contracts.Requests;

/// <summary>
/// Step 6: Tasks vom Ticket laden
/// </summary>
public record LoadTasksRequest(StepContext Context) : IRequest<StepResult>;
