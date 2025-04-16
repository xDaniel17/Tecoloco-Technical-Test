using Microsoft.EntityFrameworkCore;
using WeatherService.src.Core.Entities.Database;

namespace WeatherService.src.Infrastructure.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }

        // DbSets para las entidades
        public DbSet<WeatherCurrent> WeatherCurrents { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional mediante Fluent API
            modelBuilder.Entity<WeatherCurrent>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.City).IsRequired().HasMaxLength(100);
                entity.Property(w => w.Country).IsRequired().HasMaxLength(100);
                entity.Property(w => w.Condition).HasMaxLength(200);
            });

            modelBuilder.Entity<WeatherForecast>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.City).IsRequired().HasMaxLength(100);
                entity.Property(w => w.Country).IsRequired().HasMaxLength(100);
                entity.Property(w => w.Condition).HasMaxLength(200);
                entity.Property(w => w.ForecastGroupId).IsRequired();
            });
        }

    }
}
