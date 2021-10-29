using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class dsadasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SalesInvoicePayment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SalesInvoiceCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SalesInvoicePayment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SalesInvoiceCost",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
