using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalesOrderLineNames",
                table: "SalesOrder",
                newName: "LinesName");

            migrationBuilder.CreateTable(
                name: "SalesInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Paid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Outstanding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SalesOrderId",
                table: "SalesInvoice",
                column: "SalesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesInvoice");

            migrationBuilder.RenameColumn(
                name: "LinesName",
                table: "SalesOrder",
                newName: "SalesOrderLineNames");
        }
    }
}
