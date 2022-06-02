using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class teste12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 9,
                column: "NameCategory",
                value: "Erotic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 9,
                column: "NameCategory",
                value: "Manga");
        }
    }
}
