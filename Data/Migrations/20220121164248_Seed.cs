using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursevi.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Predavaci",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { -5, "e@e.e", "Hjk", "Kl" },
                    { -4, "d@d.d", "Uio", "Op" },
                    { -3, "c@c.c", "Zxc", "Vbn" },
                    { -2, "b@b.b", "Qwe", "Rty" },
                    { -1, "a@a.a", "Asd", "Qwe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Predavaci",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Predavaci",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Predavaci",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Predavaci",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Predavaci",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
