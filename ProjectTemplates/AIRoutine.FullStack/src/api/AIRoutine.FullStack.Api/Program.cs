using AIRoutine.FullStack.Api.Contracts.Mediator.Requests;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddShinyMediator();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
    _ = app.MapScalarApiReference();
}

app.UseHttpsRedirection();

_ = app.MapGet("/weatherforecast", async (IMediator mediator, int? days) =>
{
    var request = new GetWeatherForecastRequest(days ?? 5);
    return await mediator.Request(request).ConfigureAwait(false);
})
.WithName("GetWeatherForecast");

app.Run();
