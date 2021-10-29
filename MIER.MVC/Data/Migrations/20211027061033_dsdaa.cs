using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIER.MVC.Data.Migrations
{
    public partial class dsdaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertBy",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SalesOrderLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SalesOrderLine",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
