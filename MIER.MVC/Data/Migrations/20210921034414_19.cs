using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsertBy",
                table: "SalesOrderLine",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "SalesOrderLine",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "SalesOrderLine",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SalesOrderLine",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SalesInvoiceCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceCost_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayment_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceCost_SalesInvoiceId",
                table: "SalesInvoiceCost",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayment_PaymentMethodId",
                table: "SalesInvoicePayment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayment_SalesInvoiceId",
                table: "SalesInvoicePayment",
                column: "SalesInvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesInvoiceCost");

            migrationBuilder.DropTable(
                name: "SalesInvoicePayment");

            migrationBuilder.DropColumn(
                name: "InsertBy",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SalesOrderLine");
        }
    }
}
