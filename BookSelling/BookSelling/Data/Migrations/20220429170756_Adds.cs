using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class Adds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserNameID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategory",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdvertsimenteCategory",
                columns: table => new
                {
                    IdAdsCategories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriasFK = table.Column<int>(type: "int", nullable: false),
                    CategoriaIdCategory = table.Column<int>(type: "int", nullable: false),
                    AdvertisementFK = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryIdCategory",
                table: "Category",
                column: "CategoryIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsimenteCategory_AdvertisementFK",
                table: "AdvertsimenteCategory",
                column: "AdvertisementFK");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsimenteCategory_CategoriaIdCategory",
                table: "AdvertsimenteCategory",
                column: "CategoriaIdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryIdCategory",
                table: "Category",
                column: "CategoryIdCategory",
                principalTable: "Category",
                principalColumn: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryIdCategory",
                table: "Category");

            migrationBuilder.DropTable(
                name: "AdvertsimenteCategory");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryIdCategory",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserNameID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CategoryIdCategory",
                table: "Category");
        }
    }
}
