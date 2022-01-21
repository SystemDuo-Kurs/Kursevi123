using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursevi.Data.Migrations
{
    public partial class StaGod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polaznici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaznici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predavaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    PredavacId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kursevi_Predavaci_PredavacId",
                        column: x => x.PredavacId,
                        principalTable: "Predavaci",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoW", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoW_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KursPolaznik",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    PolazniksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursPolaznik", x => new { x.CoursesId, x.PolazniksId });
                    table.ForeignKey(
                        name: "FK_KursPolaznik_Kursevi_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursPolaznik_Polaznici_PolazniksId",
                        column: x => x.PolazniksId,
                        principalTable: "Polaznici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DoW",
                columns: new[] { "Id", "DayOfWeek", "KursId" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null },
                    { 3, 3, null },
                    { 4, 4, null },
                    { 5, 5, null },
                    { 6, 6, null },
                    { 7, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoW_KursId",
                table: "DoW",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_PredavacId",
                table: "Kursevi",
                column: "PredavacId");

            migrationBuilder.CreateIndex(
                name: "IX_KursPolaznik_PolazniksId",
                table: "KursPolaznik",
                column: "PolazniksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoW");

            migrationBuilder.DropTable(
                name: "KursPolaznik");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Polaznici");

            migrationBuilder.DropTable(
                name: "Predavaci");
        }
    }
}
