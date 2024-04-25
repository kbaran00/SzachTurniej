using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class tournamentRegulations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Regulation",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePhoto", "SecurityStamp" },
                values: new object[] { "00d6786d-e287-462a-bef4-14155024b88e", "AQAAAAIAAYagAAAAEHp/GsqSupqRtoX03rbS3pFJ0FOl0wx+TLlQ0dmsmse/zXSIiw8TpH290LlcfVrMkA==", "default.jpg", "a5ad3cd0-e7ef-410f-9496-608f88f7c556" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Regulation",
                table: "Tournaments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePhoto", "SecurityStamp" },
                values: new object[] { "21886b87-1d7b-4392-95f2-dc6068ba5a67", "AQAAAAIAAYagAAAAEOpNrQm7d3cjc+D+mAZEKD2N5Q25q6PG+0ZbExa5LlHJMhf6alVJtqeYvCnLR8GJLQ==", null, "8ddfde81-49d6-427a-a97e-2392e5eb2d34" });
        }
    }
}
