using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class purchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Purchase");
        }
    }
}
