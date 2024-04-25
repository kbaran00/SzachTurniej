using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class float_instead_of_in_for_match_score : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Player2Score",
                table: "Matches",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Player1Score",
                table: "Matches",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba869b3e-7b50-4b69-a7cb-bc268a50860c", "AQAAAAIAAYagAAAAEBca820CaNBbme8WiYzcJxv8Iex6KeiS8RBS4pJCddS41egITjkE6WjYy/NAGiOKdw==", "ec76c1ce-8b58-4a61-a62a-20fd08ca3b2a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Player2Score",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Player1Score",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b84d7c-d959-4463-add8-d05385d91554", "AQAAAAIAAYagAAAAEA0HDCbybTlMhKet6+EeIzFCZvgmEs+HJDIaLpOWUf7dhFEBkl3IKV1pSEv5vnVVPw==", "51c57452-04ef-475e-a3c0-10f9d4079ce1" });
        }
    }
}
