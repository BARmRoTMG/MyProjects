using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSimulator.Migrations
{
    /// <inheritdoc />
    public partial class LoggerFlightNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Flights_FlightId",
                table: "Logger");

            migrationBuilder.DropIndex(
                name: "IX_Logger_FlightId",
                table: "Logger");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Logger");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Logger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Logger");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Logger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logger_FlightId",
                table: "Logger",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Flights_FlightId",
                table: "Logger",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
