using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherService.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryDateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "QueryDate",
                table: "WeatherForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "QueryDate",
                table: "WeatherCurrents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueryDate",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "QueryDate",
                table: "WeatherCurrents");
        }
    }
}
