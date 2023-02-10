using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.Dal.Migrations
{
    public partial class UpdatedDeleteBehaviorBrandEngine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Companies_CompanyName",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Companies_CompanyName",
                table: "Engines");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Companies_CompanyName",
                table: "Brands",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "CompanyName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Companies_CompanyName",
                table: "Engines",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "CompanyName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Companies_CompanyName",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Companies_CompanyName",
                table: "Engines");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Companies_CompanyName",
                table: "Brands",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "CompanyName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Companies_CompanyName",
                table: "Engines",
                column: "CompanyName",
                principalTable: "Companies",
                principalColumn: "CompanyName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
