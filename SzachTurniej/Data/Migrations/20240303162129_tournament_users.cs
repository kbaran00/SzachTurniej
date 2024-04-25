using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class tournament_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "TournamentId" },
                values: new object[] { "1b5c869f-8a83-470a-9db1-7fa0d1487edf", "AQAAAAIAAYagAAAAEL8rsxpdPwatHDq8SWU/s9pRjqHt4dQ7nYfkmFvyRZmpI/IT+atfivk0z7+8dN2GCw==", "34c1e774-74d0-49e5-9659-56789cfdc706", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TournamentId",
                table: "AspNetUsers",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tournaments_TournamentId",
                table: "AspNetUsers",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tournaments_TournamentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TournamentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00d6786d-e287-462a-bef4-14155024b88e", "AQAAAAIAAYagAAAAEHp/GsqSupqRtoX03rbS3pFJ0FOl0wx+TLlQ0dmsmse/zXSIiw8TpH290LlcfVrMkA==", "a5ad3cd0-e7ef-410f-9496-608f88f7c556" });
        }
    }
}
