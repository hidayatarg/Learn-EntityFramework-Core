using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreWebApp.Migrations
{
    public partial class AddToDoDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "ToDos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "ToDos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ToDos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ToDos");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "ToDos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
