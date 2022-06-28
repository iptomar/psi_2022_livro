using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class testRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserReview",
                columns: table => new
                {
                    IdReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueReview = table.Column<double>(type: "float", nullable: false),
                    DateReview = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    Utilizador2FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview", x => x.IdReview);
                    table.ForeignKey(
                        name: "FK_UserReview_Utilizadores_Utilizador2FK",
                        column: x => x.Utilizador2FK,
                        principalTable: "Utilizadores",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReview_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_Utilizador2FK",
                table: "UserReview",
                column: "Utilizador2FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_UtilizadorFK",
                table: "UserReview",
                column: "UtilizadorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReview");
        }
    }
}
