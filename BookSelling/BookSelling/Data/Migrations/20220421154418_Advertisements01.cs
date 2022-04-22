using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class Advertisements01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Advertisement");
        }
    }
}
