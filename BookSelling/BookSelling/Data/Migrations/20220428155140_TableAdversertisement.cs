using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class TableAdversertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "AdvertisementAdID", "NameCategory" },
                values: new object[] { 1, null, "Fantasy" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "AdvertisementAdID", "NameCategory" },
                values: new object[] { 2, null, "Action" });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_User_UserID",
                table: "Advertisement",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Advertisement_AdvertisementAdID",
                table: "Category",
                column: "AdvertisementAdID",
                principalTable: "Advertisement",
                principalColumn: "AdID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_User_UserID",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Advertisement_AdvertisementAdID",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 2);
        }
    }
}
