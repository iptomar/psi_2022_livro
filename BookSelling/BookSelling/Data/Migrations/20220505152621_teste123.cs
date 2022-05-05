using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class teste123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertsimenteCategory");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 1,
                column: "NameCategory",
                value: "Action");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 2,
                column: "NameCategory",
                value: "Adventure");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "AdvertisementAdID", "CategoryIdCategory", "NameCategory" },
                values: new object[,]
                {
                    { 3, null, null, "Comedy" },
                    { 4, null, null, "Drama" },
                    { 5, null, null, "Fantasy" },
                    { 6, null, null, "Science Fiction" },
                    { 7, null, null, "Romance" },
                    { 8, null, null, "Horror" },
                    { 9, null, null, "Manga" },
                    { 10, null, null, "Thriller" },
                    { 11, null, null, "Kids" },
                    { 12, null, null, "Mistery" },
                    { 13, null, null, "Suspance" },
                    { 14, null, null, "Comics Books" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 14);

            migrationBuilder.CreateTable(
                name: "AdvertsimenteCategory",
                columns: table => new
                {
                    IdAdsCategories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementFK = table.Column<int>(type: "int", nullable: false),
                    CategoriaIdCategory = table.Column<int>(type: "int", nullable: false),
                    CategoriasFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertsimenteCategory", x => x.IdAdsCategories);
                    table.ForeignKey(
                        name: "FK_AdvertsimenteCategory_Advertisement_AdvertisementFK",
                        column: x => x.AdvertisementFK,
                        principalTable: "Advertisement",
                        principalColumn: "AdID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertsimenteCategory_Category_CategoriaIdCategory",
                        column: x => x.CategoriaIdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 1,
                column: "NameCategory",
                value: "Fantasy");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 2,
                column: "NameCategory",
                value: "Action");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsimenteCategory_AdvertisementFK",
                table: "AdvertsimenteCategory",
                column: "AdvertisementFK");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsimenteCategory_CategoriaIdCategory",
                table: "AdvertsimenteCategory",
                column: "CategoriaIdCategory");
        }
    }
}
