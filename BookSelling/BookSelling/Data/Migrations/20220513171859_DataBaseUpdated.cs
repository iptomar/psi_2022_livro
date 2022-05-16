﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSelling.Data.Migrations
{
    public partial class DataBaseUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ISBM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sold = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
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
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementAdID = table.Column<int>(type: "int", nullable: true),
                    CategoryIdCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                    table.ForeignKey(
                        name: "FK_Category_Advertisement_AdvertisementAdID",
                        column: x => x.AdvertisementAdID,
                        principalTable: "Advertisement",
                        principalColumn: "AdID");
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryIdCategory",
                        column: x => x.CategoryIdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "AdvertisementAdID", "CategoryIdCategory", "NameCategory" },
                values: new object[,]
                {
                    { 1, null, null, "Action" },
                    { 2, null, null, "Adventure" },
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
                name: "IX_Advertisement_CategoryID",
                table: "Advertisement",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserID",
                table: "Advertisement",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_AdvertisementAdID",
                table: "Category",
                column: "AdvertisementAdID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryIdCategory",
                table: "Category",
                column: "CategoryIdCategory");

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

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
