using Moq;
using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;

public class GetCurrentWeatherUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_ReturnsWeatherData_WhenCityIsValid()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        var city = "San Salvador";
        var expectedWeather = new WeatherData { City = city };

        mockWeatherService
            .Setup(service => service.GetCurrentWeatherAsync(city))
            .ReturnsAsync(expectedWeather);

        var useCase = new GetCurrentWeatherUseCase(mockWeatherService.Object);

        // Act
        var result = await useCase.ExecuteAsync(city);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedWeather.City, result.City);
        mockWeatherService.Verify(service => service.GetCurrentWeatherAsync(city), Times.Once);
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsException_WhenWeatherServiceFails()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();
        var city = "InvalidCity";

        mockWeatherService
            .Setup(service => service.GetCurrentWeatherAsync(city))
            .ThrowsAsync(new InvalidOperationException("City not found"));

        var useCase = new GetCurrentWeatherUseCase(mockWeatherService.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => useCase.ExecuteAsync(city));
    }
}