using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Interfaces;
using WeatherService.src.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IWeatherService, WeatherbitService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["WeatherAPI:BaseURL"]);
});

builder.Services.AddScoped<GetCurrentWeatherUseCase>();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();