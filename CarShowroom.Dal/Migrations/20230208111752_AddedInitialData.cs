using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.Dal.Migrations
{
    public partial class AddedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyName", "CompanySite" },
                values: new object[] { "Daimler", "daimler.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyName", "CompanySite" },
                values: new object[] { "PSA Groupe", "psa.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyName", "CompanySite" },
                values: new object[] { "VAG", "vag.com" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CompanyName", "Name" },
                values: new object[,]
                {
                    { 1, "VAG", "Volkswagen" },
                    { 2, "VAG", "Audi" },
                    { 3, "Daimler", "Mercedes-Benz" },
                    { 4, "PSA Groupe", "Citroen" },
                    { 5, "PSA Groupe", "Peugeot" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyName",
                keyValue: "Daimler");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyName",
                keyValue: "PSA Groupe");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyName",
                keyValue: "VAG");
        }
    }
}
