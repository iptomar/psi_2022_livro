using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class Sprint2_Lulu_Fred : Migration
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

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Reputation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooksSold = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    AdID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeofAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ISBM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sold = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.AdID);
                    table.ForeignKey(
                        name: "FK_Advertisement_Utilizadores_UserID",
                        column: x => x.UserID,
                        principalTable: "Utilizadores",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementID = table.Column<int>(type: "int", nullable: false),
                    UtilizadoresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorite_Advertisement_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisement",
                        principalColumn: "AdID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorite_Utilizadores_UtilizadoresID",
                        column: x => x.UtilizadoresID,
                        principalTable: "Utilizadores",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "NameCategory" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Comedy" },
                    { 4, "Drama" },
                    { 5, "Fantasy" },
                    { 6, "Science Fiction" },
                    { 7, "Romance" },
                    { 8, "Horror" },
                    { 9, "Manga" },
                    { 10, "Thriller" },
                    { 11, "Kids" },
                    { 12, "Mistery" },
                    { 13, "Suspance" },
                    { 14, "Comics Books" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserID",
                table: "Advertisement",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsCategory_AdvertisementFK",
                table: "AdvertsCategory",
                column: "AdvertisementFK");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsCategory_CategoryFK",
                table: "AdvertsCategory",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_AdvertisementID",
                table: "Favorite",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UtilizadoresID",
                table: "Favorite",
                column: "UtilizadoresID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertsCategory");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
