using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class delete_tournament_system : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "System",
                table: "Tournaments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e9b8004-6c5a-4914-b8aa-d4339d5a0327", "AQAAAAIAAYagAAAAEJ8AettmmE+26MK5tc/9hOslIjYPlwlF7txx9W4gR9JGqdhdEemaO0UNMKiRQ62ZyQ==", "1adf4d80-062d-4a85-a7dc-250254e77b7f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "System",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cbaa321-378d-4200-a842-b8874dbf0af9", "AQAAAAIAAYagAAAAEIsIgiIdDBdT/G0kEAREBzh6OmOcAbzY2JkWZW3nuMHlSHxoQy/oqCo3E4GQiBY0zw==", "5f5baf22-0483-4257-a617-5044c4a80571" });
        }
    }
}
