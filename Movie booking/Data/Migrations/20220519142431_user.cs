using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_booking.Data.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "bookingtable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "applicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookNowViewmodel",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movie_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookNowViewmodel", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetailViewmodel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofMovie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoviePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetailViewmodel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingtable_ApplicationUserId",
                table: "bookingtable",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingtable_applicationUsers_ApplicationUserId",
                table: "bookingtable",
                column: "ApplicationUserId",
                principalTable: "applicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingtable_applicationUsers_ApplicationUserId",
                table: "bookingtable");

            migrationBuilder.DropTable(
                name: "applicationUsers");

            migrationBuilder.DropTable(
                name: "BookNowViewmodel");

            migrationBuilder.DropTable(
                name: "MovieDetailViewmodel");

            migrationBuilder.DropIndex(
                name: "IX_bookingtable_ApplicationUserId",
                table: "bookingtable");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "bookingtable");
        }
    }
}
