using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.Dal.Migrations
{
    public partial class AddInitDataEquipmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "EngineId", "ModelId", "Name", "Price" },
                values: new object[] { 1, 1, 1, "Comfort", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
