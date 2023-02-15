using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.Dal.Migrations
{
    public partial class AddInitDataAutomobileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Automobiles",
                columns: new[] { "VIN", "BodyType", "BrandId", "Color", "EquipmentId", "ModelId", "ProdDate" },
                values: new object[] { "QWERTYUIOPASDFGHJ", 0, 1, 1, 1, 1, new DateTime(2022, 2, 16, 0, 54, 30, 165, DateTimeKind.Local).AddTicks(8888) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Automobiles",
                keyColumn: "VIN",
                keyValue: "QWERTYUIOPASDFGHJ");
        }
    }
}
