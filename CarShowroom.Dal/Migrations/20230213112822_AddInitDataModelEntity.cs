using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.Dal.Migrations
{
    public partial class AddInitDataModelEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[] { 1, 1, "Passat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
