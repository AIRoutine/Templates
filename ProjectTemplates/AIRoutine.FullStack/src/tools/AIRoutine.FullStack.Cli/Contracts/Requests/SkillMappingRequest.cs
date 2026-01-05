using Shiny.Mediator;

namespace AIRoutine.FullStack.Cli.Contracts.Requests;

/// <summary>
/// Step 5: Skills Zuordnung
/// </summary>
public record SkillMappingRequest(StepContext Context) : IRequest<StepResult>;
