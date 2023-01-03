using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_booking.Data.Migrations
{
    public partial class moviebooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seatno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moviedetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moviename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movie_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateandTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoviePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviedetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookingtable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seatno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datetopresent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moviedetailsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingtable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookingtable_moviedetail_moviedetailsId",
                        column: x => x.moviedetailsId,
                        principalTable: "moviedetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingtable_moviedetailsId",
                table: "bookingtable",
                column: "moviedetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingtable");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "moviedetail");
        }
    }
}
