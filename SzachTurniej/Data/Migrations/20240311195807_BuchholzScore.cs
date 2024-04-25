using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class BuchholzScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BuchholzScore",
                table: "TournamentStandings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cbaa321-378d-4200-a842-b8874dbf0af9", "AQAAAAIAAYagAAAAEIsIgiIdDBdT/G0kEAREBzh6OmOcAbzY2JkWZW3nuMHlSHxoQy/oqCo3E4GQiBY0zw==", "5f5baf22-0483-4257-a617-5044c4a80571" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuchholzScore",
                table: "TournamentStandings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0332a55-d186-4e29-b555-035f5cba3ac5", "AQAAAAIAAYagAAAAEFWYZ1GXqDipYOGY84Aig2sVy0X6ztXFroyVUK0nPA9iyYekpu86dXptEmOrooX9CQ==", "fbe0fd06-0ffb-4125-8052-a74f1fa6e3b9" });
        }
    }
}
