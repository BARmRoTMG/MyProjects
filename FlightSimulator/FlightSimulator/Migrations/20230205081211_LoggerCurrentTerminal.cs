using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSimulator.Migrations
{
    /// <inheritdoc />
    public partial class LoggerCurrentTerminal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Terminals_TerminalId",
                table: "Logger");

            migrationBuilder.DropIndex(
                name: "IX_Logger_TerminalId",
                table: "Logger");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "Logger");

            migrationBuilder.AddColumn<string>(
                name: "CurrentTerminal",
                table: "Logger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTerminal",
                table: "Logger");

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "Logger",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logger_TerminalId",
                table: "Logger",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Terminals_TerminalId",
                table: "Logger",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id");
        }
    }
}
