using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class standing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Points",
                table: "TournamentStandings",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0332a55-d186-4e29-b555-035f5cba3ac5", "AQAAAAIAAYagAAAAEFWYZ1GXqDipYOGY84Aig2sVy0X6ztXFroyVUK0nPA9iyYekpu86dXptEmOrooX9CQ==", "fbe0fd06-0ffb-4125-8052-a74f1fa6e3b9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "TournamentStandings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c58f3bb0-9208-4104-9382-4f49c9e1ef4f", "AQAAAAIAAYagAAAAEAaHeCUtVQ4cTeu4ESZ4eNaAEm+ODgpOhv5+FFsX6rNF7vnP6oE/f/XsEjL33WgtMA==", "ee429e56-33b9-41c8-8927-8676ae6cc576" });
        }
    }
}
