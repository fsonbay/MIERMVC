using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "SalesOrder",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "SalesOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionStatusId",
                table: "SalesOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerId",
                table: "SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_ProductionStatusId",
                table: "SalesOrder",
                column: "ProductionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_Customer_CustomerId",
                table: "SalesOrder",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_ProductionStatus_ProductionStatusId",
                table: "SalesOrder",
                column: "ProductionStatusId",
                principalTable: "ProductionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_Customer_CustomerId",
                table: "SalesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_ProductionStatus_ProductionStatusId",
                table: "SalesOrder");

            migrationBuilder.DropTable(
                name: "SalesOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrder_CustomerId",
                table: "SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrder_ProductionStatusId",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "ProductionStatusId",
                table: "SalesOrder");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "SalesOrder",
                newName: "IsDelete");
        }
    }
}
