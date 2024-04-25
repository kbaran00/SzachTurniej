using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzachTurniej.Migrations
{
    /// <inheritdoc />
    public partial class add_user_club : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Club", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "e6ee18e0-aaee-4597-8058-b89c5c5806ae", "AQAAAAIAAYagAAAAEHXT2ASosfpqRcWEa4j2AWmASibHyoaDWwPTAwZYHpZkjbCKy3ZirIaKejRpz4gooA==", "02784347-02dd-4bf5-ade1-9dfa0225683e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b5c869f-8a83-470a-9db1-7fa0d1487edf", "AQAAAAIAAYagAAAAEL8rsxpdPwatHDq8SWU/s9pRjqHt4dQ7nYfkmFvyRZmpI/IT+atfivk0z7+8dN2GCw==", "34c1e774-74d0-49e5-9659-56789cfdc706" });
        }
    }
}
