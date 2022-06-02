using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class Machine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PaymentMethodId",
                table: "Purchase",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SalesOrderId",
                table: "Purchase",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_PaymentMethod_PaymentMethodId",
                table: "Purchase",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_SalesOrder_SalesOrderId",
                table: "Purchase",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_PaymentMethod_PaymentMethodId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_SalesOrder_SalesOrderId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_PaymentMethodId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_SalesOrderId",
                table: "Purchase");
        }
    }
}
