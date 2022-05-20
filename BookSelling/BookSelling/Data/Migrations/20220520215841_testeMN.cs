using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class testeMN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Category_CategoryID",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Advertisement_AdvertisementAdID",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_AdvertisementAdID",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_CategoryID",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "AdvertisementAdID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Advertisement");

            migrationBuilder.CreateTable(
                name: "AdvertsCategory",
                columns: table => new
                {
                    IdAdvertsCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryFK = table.Column<int>(type: "int", nullable: false),
                    AdvertisementFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertsCategory", x => x.IdAdvertsCategory);
                    table.ForeignKey(
                        name: "FK_AdvertsCategory_Advertisement_AdvertisementFK",
                        column: x => x.AdvertisementFK,
                        principalTable: "Advertisement",
                        principalColumn: "AdID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertsCategory_Category_CategoryFK",
                        column: x => x.CategoryFK,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsCategory_AdvertisementFK",
                table: "AdvertsCategory",
                column: "AdvertisementFK");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsCategory_CategoryFK",
                table: "AdvertsCategory",
                column: "CategoryFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertsCategory");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementAdID",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Advertisement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Category_AdvertisementAdID",
                table: "Category",
                column: "AdvertisementAdID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_CategoryID",
                table: "Advertisement",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Category_CategoryID",
                table: "Advertisement",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Advertisement_AdvertisementAdID",
                table: "Category",
                column: "AdvertisementAdID",
                principalTable: "Advertisement",
                principalColumn: "AdID");
        }
    }
}
