using AIRoutine.FullStack.Api.Contracts.Mediator.Requests;

namespace AIRoutine.FullStack.Api.Handlers;

[MediatorScoped]
public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastRequest, IEnumerable<WeatherForecastResponse>>
{
    private static readonly string[] s_summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

#pragma warning disable IDE1006 // Naming rule - interface defines method name
    public Task<IEnumerable<WeatherForecastResponse>> Handle(
#pragma warning restore IDE1006
        GetWeatherForecastRequest request,
        IMediatorContext context,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

#pragma warning disable CA5394 // Random is fine for non-security weather demo data
        var forecast = Enumerable.Range(1, request.Days)
            .Select(index => new WeatherForecastResponse(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                s_summaries[Random.Shared.Next(s_summaries.Length)]
            ));
#pragma warning restore CA5394

        return Task.FromResult(forecast);
    }
}
