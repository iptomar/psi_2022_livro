using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class FixdaMigracaoanterior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Advertisement_AdvertisementID",
                table: "Favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Utilizadores_UtilizadoresID",
                table: "Favorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite");

            migrationBuilder.RenameTable(
                name: "Favorite",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Favorite_UtilizadoresID",
                table: "Favorites",
                newName: "IX_Favorites_UtilizadoresID");

            migrationBuilder.RenameIndex(
                name: "IX_Favorite_AdvertisementID",
                table: "Favorites",
                newName: "IX_Favorites_AdvertisementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Advertisement_AdvertisementID",
                table: "Favorites",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "AdID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Utilizadores_UtilizadoresID",
                table: "Favorites",
                column: "UtilizadoresID",
                principalTable: "Utilizadores",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Advertisement_AdvertisementID",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Utilizadores_UtilizadoresID",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favorite");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UtilizadoresID",
                table: "Favorite",
                newName: "IX_Favorite_UtilizadoresID");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_AdvertisementID",
                table: "Favorite",
                newName: "IX_Favorite_AdvertisementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Advertisement_AdvertisementID",
                table: "Favorite",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "AdID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Utilizadores_UtilizadoresID",
                table: "Favorite",
                column: "UtilizadoresID",
                principalTable: "Utilizadores",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
