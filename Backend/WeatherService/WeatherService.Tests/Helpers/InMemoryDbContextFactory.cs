using Microsoft.EntityFrameworkCore;
using WeatherService.src.Infrastructure.Data;

public static class InMemoryDbContextFactory
{
    public static WeatherDbContext Create()
    {
        var options = new DbContextOptionsBuilder<WeatherDbContext>()
            .UseInMemoryDatabase(databaseName: "WeatherTestDb")
            .Options;

        return new WeatherDbContext(options);
    }
}