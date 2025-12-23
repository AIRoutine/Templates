using Shiny.Mediator;

namespace AIRoutine.FullStack.Api.Contracts.Mediator.Requests;

public record GetWeatherForecastRequest(int Days = 5) : IRequest<IEnumerable<WeatherForecastResponse>>;
