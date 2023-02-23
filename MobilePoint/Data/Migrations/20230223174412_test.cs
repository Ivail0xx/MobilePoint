using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilePoint.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandModels_BrandModels_BrandModelId",
                table: "BrandModels");

            migrationBuilder.DropIndex(
                name: "IX_BrandModels_BrandModelId",
                table: "BrandModels");

            migrationBuilder.DropColumn(
                name: "BrandModelId",
                table: "BrandModels");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Phones",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Phones",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "BrandModelId",
                table: "BrandModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrandModels_BrandModelId",
                table: "BrandModels",
                column: "BrandModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandModels_BrandModels_BrandModelId",
                table: "BrandModels",
                column: "BrandModelId",
                principalTable: "BrandModels",
                principalColumn: "Id");
        }
    }
}
