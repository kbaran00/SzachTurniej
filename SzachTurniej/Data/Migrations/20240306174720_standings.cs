using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class standings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TournamentStandings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentStandings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentStandings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentStandings_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3d67422-52dc-46f7-8183-85ba201d290d", "AQAAAAIAAYagAAAAEBw6+qmn+sMnVDY9AUEhEGtbTUMDvKzVZvyfE9pF904+rGOCjWGGyXECW9CEufu8vw==", "b8ce54d6-82df-4c95-b9d6-bd05e1accaef" });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStandings_TournamentId",
                table: "TournamentStandings",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStandings_UserId",
                table: "TournamentStandings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentStandings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6079f9c-d8c9-4e35-b82e-4f08c3abb0ce", "AQAAAAIAAYagAAAAEDdl+b1nO35NbPPUDU/DohWLRxPb/Kx1NZvgsa8HXCK5X8fnjzRjT+vSA4ngD9KyAw==", "9fe410af-f40e-4f4a-9594-9dbb93470fd5" });
        }
    }
}
