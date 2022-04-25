using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class addCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "NameCategory" },
                values: new object[] { 1, "Fantasy" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "NameCategory" },
                values: new object[] { 2, "Action" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
