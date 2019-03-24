using Microsoft.EntityFrameworkCore.Migrations;

namespace TostiBackEnd.Migrations
{
    public partial class CreateTostiTable_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tostis",
                columns: new[] { "Id", "Brood", "Calorieen", "Naam", "Vulling" },
                values: new object[] { 1, "Witbrood", 400, "HamKaas", "Ham en Kaas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tostis",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
