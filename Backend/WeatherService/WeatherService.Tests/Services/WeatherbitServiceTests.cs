using Moq;
using Moq.Protected;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherService.src.Infrastructure.Services;
using WeatherService.src.Core.Entities;
using Xunit;

public class WeatherbitServiceTests
{
    [Fact]
    public async Task GetCurrentWeatherAsync_CachesResult_AfterFirstCall()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        var mockCache = new MemoryCache(new MemoryCacheOptions());
        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(config => config["WeatherAPI:ApiKey"]).Returns("dummyApiKey");
        mockConfig.Setup(config => config["WeatherAPI:BaseUrl"]).Returns("https://api.weatherbit.io/v2.0/");

        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"data\": [{\"city_name\": \"San Salvador\", \"temp\": 25.5}]}")
            });

        var httpClient = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new System.Uri(mockConfig.Object["WeatherAPI:BaseUrl"])
        };

        var weatherService = new WeatherbitService(httpClient, mockConfig.Object, mockCache);
        var city = "San Salvador";

        // Act
        var result1 = await weatherService.GetCurrentWeatherAsync(city);
        var result2 = await weatherService.GetCurrentWeatherAsync(city);

        // Assert
        Assert.Equal(result1.Temperature, result2.Temperature);
        Assert.True(mockCache.TryGetValue($"current_weather_{city.ToLower()}", out _));
    }
}