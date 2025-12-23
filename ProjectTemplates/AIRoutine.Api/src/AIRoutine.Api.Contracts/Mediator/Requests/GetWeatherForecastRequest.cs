using Shiny.Mediator;

namespace AIRoutine.Api.Contracts.Mediator.Requests;

public record GetWeatherForecastRequest(int Days = 5) : IRequest<IEnumerable<WeatherForecastResponse>>;
