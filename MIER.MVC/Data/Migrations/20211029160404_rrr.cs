using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class rrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertBy",
                table: "SalesInvoicePayment");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "SalesInvoicePayment");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "SalesInvoicePayment");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SalesInvoicePayment");

            migrationBuilder.DropColumn(
                name: "InsertBy",
                table: "SalesInvoiceCost");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "SalesInvoiceCost");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "SalesInvoiceCost");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SalesInvoiceCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsertBy",
                table: "SalesInvoicePayment",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "SalesInvoicePayment",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "SalesInvoicePayment",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SalesInvoicePayment",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertBy",
                table: "SalesInvoiceCost",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "SalesInvoiceCost",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "SalesInvoiceCost",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SalesInvoiceCost",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
