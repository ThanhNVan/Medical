using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptUni.BpHostpital.HR.Utils.Migrations
{
    public partial class AddDateTimeInAndOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Attendance",
                newName: "DateTimeOut");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeIn",
                table: "Attendance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeIn",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "DateTimeOut",
                table: "Attendance",
                newName: "DateTime");
        }
    }
}
