using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class nullable_palyers_in_match : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c58f3bb0-9208-4104-9382-4f49c9e1ef4f", "AQAAAAIAAYagAAAAEAaHeCUtVQ4cTeu4ESZ4eNaAEm+ODgpOhv5+FFsX6rNF7vnP6oE/f/XsEjL33WgtMA==", "ee429e56-33b9-41c8-8927-8676ae6cc576" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2091a181-b4bd-41c7-8466-4951d85cdb85", "AQAAAAIAAYagAAAAEF8UAofsDsJiET7E+HhTPN5Z8oFJjSeYVQJw9a+SAg6tToD8emlpATJw8miH7gtS8A==", "504c1569-f408-492c-b998-56765e5c910e" });
        }
    }
}
