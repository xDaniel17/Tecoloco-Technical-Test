using Moq;
using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;

public class GetDailyForecastUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_ReturnsForecastData_WhenCityAndDaysAreValid()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        var city = "San Salvador";
        var days = 7;
        var expectedForecast = new List<WeatherData>
        {
            new WeatherData { City = city, Date = DateTime.Now.AddDays(1) },
            new WeatherData { City = city, Date = DateTime.Now.AddDays(2) }
        };

        mockWeatherService
            .Setup(service => service.GetDailyForecastAsync(city, days))
            .ReturnsAsync(expectedForecast);

        var useCase = new GetDailyForecastUseCase(mockWeatherService.Object);

        // Act
        var result = await useCase.ExecuteAsync(city, days);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedForecast.Count, result.Count);
        Assert.All(result, item => Assert.Equal(city, item.City));
        mockWeatherService.Verify(service => service.GetDailyForecastAsync(city, days), Times.Once);
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsArgumentException_WhenCityIsEmpty()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        var city = string.Empty;
        var days = 7;

        var useCase = new GetDailyForecastUseCase(mockWeatherService.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => useCase.ExecuteAsync(city, days));
        Assert.Equal("City name cannot be empty or null.", exception.Message);
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsArgumentException_WhenDaysAreInvalid()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        var city = "San Salvador";
        var days = 0;

        var useCase = new GetDailyForecastUseCase(mockWeatherService.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => useCase.ExecuteAsync(city, days));
        Assert.Equal("Number of days must be greater than zero.", exception.Message);
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsException_WhenWeatherServiceFails()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        var city = "InvalidCity";
        var days = 7;

        mockWeatherService
            .Setup(service => service.GetDailyForecastAsync(city, days))
            .ThrowsAsync(new InvalidOperationException("City not found"));

        var useCase = new GetDailyForecastUseCase(mockWeatherService.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => useCase.ExecuteAsync(city, days));
        Assert.Equal("City not found", exception.Message);
    }
}