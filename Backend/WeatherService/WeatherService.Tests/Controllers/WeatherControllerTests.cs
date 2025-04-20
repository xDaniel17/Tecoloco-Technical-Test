using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;
using WeatherService.src.Presentation.Controllers;
using WeatherService.src.Presentation.Models;

public class WeatherControllerTests
{
    [Fact]
    public async Task GetCurrentWeather_ReturnsOkResult_WhenCityIsValid()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        mockWeatherService
            .Setup(service => service.GetCurrentWeatherAsync("San Salvador"))
            .ReturnsAsync(new WeatherData { City = "San Salvador", Temperature = 25.5f });

        var useCase = new GetCurrentWeatherUseCase(mockWeatherService.Object);

        var dbContext = InMemoryDbContextFactory.Create();
        var controller = new WeatherController(useCase, null, dbContext);

        // Act
        var result = await controller.GetCurrentWeather("San Salvador");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsAssignableFrom<BaseResponse<WeatherData>>(okResult.Value); // Cambiado a BaseResponse<WeatherData>
        Assert.Equal(200, response.ResultCode);
        Assert.NotNull(response.Content);
        Assert.Equal("San Salvador", response.Content.City);
        Assert.Equal(25.5f, response.Content.Temperature);
    }
}