using Microsoft.EntityFrameworkCore;
using Serilog;
using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Interfaces;
using WeatherService.src.Infrastructure.Data;
using WeatherService.src.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddHttpClient<IWeatherService, WeatherbitService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["WeatherAPI:BaseURL"]);
});

// Configurar Serilog
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration) // Leer configuración desde appsettings.json
        .WriteTo.Console() // Registrar en la consola
        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day); // Registrar en archivo
});

builder.Services.AddScoped<GetCurrentWeatherUseCase>();
builder.Services.AddScoped<GetDailyForecastUseCase>();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Depende de la url del frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseMiddleware<WeatherService.src.Middleware.ExceptionMiddleware>();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();