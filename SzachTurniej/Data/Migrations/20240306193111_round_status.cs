using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class round_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TournamentRounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2091a181-b4bd-41c7-8466-4951d85cdb85", "AQAAAAIAAYagAAAAEF8UAofsDsJiET7E+HhTPN5Z8oFJjSeYVQJw9a+SAg6tToD8emlpATJw8miH7gtS8A==", "504c1569-f408-492c-b998-56765e5c910e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TournamentRounds");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3d67422-52dc-46f7-8183-85ba201d290d", "AQAAAAIAAYagAAAAEBw6+qmn+sMnVDY9AUEhEGtbTUMDvKzVZvyfE9pF904+rGOCjWGGyXECW9CEufu8vw==", "b8ce54d6-82df-4c95-b9d6-bd05e1accaef" });
        }
    }
}
