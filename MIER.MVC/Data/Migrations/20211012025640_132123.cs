using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class _132123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PaymentMethod",
                type: "varchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PaymentMethod",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)");
        }
    }
}
