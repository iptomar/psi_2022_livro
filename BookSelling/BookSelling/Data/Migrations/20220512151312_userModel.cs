using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class userModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameID",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserNameID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
