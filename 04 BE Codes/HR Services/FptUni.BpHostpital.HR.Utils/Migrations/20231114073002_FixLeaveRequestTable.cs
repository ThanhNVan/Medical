using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptUni.BpHostpital.HR.Utils.Migrations
{
    public partial class FixLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "LeaveRequest",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "LeaveRequest");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "LeaveRequest",
                newName: "Date");
        }
    }
}
