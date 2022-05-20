using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class SolvedControllerAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryIdCategory",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryIdCategory",
                table: "Category");

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

            migrationBuilder.DropColumn(
                name: "CategoryIdCategory",
                table: "Category");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategory",
                table: "Category",
                type: "int",
                nullable: true);

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
                    { 9, null, null, "Erotic" },
                    { 10, null, null, "Thriller" },
                    { 11, null, null, "Kids" },
                    { 12, null, null, "Mistery" },
                    { 13, null, null, "Suspance" },
                    { 14, null, null, "Comics Books" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryIdCategory",
                table: "Category",
                column: "CategoryIdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryIdCategory",
                table: "Category",
                column: "CategoryIdCategory",
                principalTable: "Category",
                principalColumn: "IdCategory");
        }
    }
}
