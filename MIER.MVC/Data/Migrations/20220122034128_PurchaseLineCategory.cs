using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class PurchaseLineCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseCategoryId",
                table: "PurchaseLine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseCategoryId",
                table: "PurchaseLine");
        }
    }
}
