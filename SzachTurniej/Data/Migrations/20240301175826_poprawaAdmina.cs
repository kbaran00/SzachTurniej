using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class poprawaAdmina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37936698-a9bf-4c66-8ed5-30b0c126f339", "AQAAAAIAAYagAAAAEA3fPBGsjE74hj+UZ9Tc3O/kP0lxKy838XzrNlOQebu/dP39H5nUUlPBJQHJ5TRBtA==", "dd12b4e3-a480-4095-92f4-88ff9424ec98" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a15bf7b1-5857-4407-9348-fd268a001e07", "AQAAAAIAAYagAAAAELbs8a3/8MeVe2HNxwH2rLJU/YWfCBWLOa8MVr7yJEzCpUTFPqcF1V+WAeHwAPDKNw==", "ca05c22b-3dfc-427d-be1f-45a7ce63e900" });
        }
    }
}
