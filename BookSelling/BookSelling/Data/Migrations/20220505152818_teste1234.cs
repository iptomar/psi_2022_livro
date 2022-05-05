using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class teste1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Advertisement",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Category_CategoryID",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_CategoryID",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Advertisement");
        }
    }
}
