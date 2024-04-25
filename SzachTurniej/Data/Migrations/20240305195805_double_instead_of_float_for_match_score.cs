using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class double_instead_of_float_for_match_score : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Player2Score",
                table: "Matches",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Player1Score",
                table: "Matches",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6079f9c-d8c9-4e35-b82e-4f08c3abb0ce", "AQAAAAIAAYagAAAAEDdl+b1nO35NbPPUDU/DohWLRxPb/Kx1NZvgsa8HXCK5X8fnjzRjT+vSA4ngD9KyAw==", "9fe410af-f40e-4f4a-9594-9dbb93470fd5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Player2Score",
                table: "Matches",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Player1Score",
                table: "Matches",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba869b3e-7b50-4b69-a7cb-bc268a50860c", "AQAAAAIAAYagAAAAEBca820CaNBbme8WiYzcJxv8Iex6KeiS8RBS4pJCddS41egITjkE6WjYy/NAGiOKdw==", "ec76c1ce-8b58-4a61-a62a-20fd08ca3b2a" });
        }
    }
}
