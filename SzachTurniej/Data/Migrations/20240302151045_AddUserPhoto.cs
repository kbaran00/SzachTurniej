using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePhoto", "SecurityStamp" },
                values: new object[] { "21886b87-1d7b-4392-95f2-dc6068ba5a67", "AQAAAAIAAYagAAAAEOpNrQm7d3cjc+D+mAZEKD2N5Q25q6PG+0ZbExa5LlHJMhf6alVJtqeYvCnLR8GJLQ==", null, "8ddfde81-49d6-427a-a97e-2392e5eb2d34" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37936698-a9bf-4c66-8ed5-30b0c126f339", "AQAAAAIAAYagAAAAEA3fPBGsjE74hj+UZ9Tc3O/kP0lxKy838XzrNlOQebu/dP39H5nUUlPBJQHJ5TRBtA==", "dd12b4e3-a480-4095-92f4-88ff9424ec98" });
        }
    }
}
