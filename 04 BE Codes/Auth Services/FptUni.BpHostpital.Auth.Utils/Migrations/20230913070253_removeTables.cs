using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptUni.BpHostpital.Auth.Utils.Migrations
{
    public partial class removeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0879656e-c736-40e6-82d1-00dd8b6579a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62ea529c-6481-42b3-ad7d-f41e1d8f5129");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67b8b922-31be-4723-8420-fc0cd01be035");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed766d6-f55d-4df6-ade2-951db61f9c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "893118eb-f6cc-4651-ba74-3b7f350131a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b60520a9-c519-44d3-a8d9-87acd32118e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db3fdcc2-fa8b-4a1c-a436-28a6132e2c32");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0879656e-c736-40e6-82d1-00dd8b6579a5", "5", "Sales Manager", "SALES MANAGER" },
                    { "62ea529c-6481-42b3-ad7d-f41e1d8f5129", "2", "Department Director", "DEPARTMENT DIRECTOR" },
                    { "67b8b922-31be-4723-8420-fc0cd01be035", "1", "Admin", "ADMINISTRATOR" },
                    { "6ed766d6-f55d-4df6-ade2-951db61f9c4d", "3", "HR Staff", "HUMAN RESOURCE STAFF" },
                    { "893118eb-f6cc-4651-ba74-3b7f350131a4", "3", "HR Manager", "HUMAN RESOURCE MANAGER" },
                    { "b60520a9-c519-44d3-a8d9-87acd32118e3", "6", "General Director", "GENERAL DIRECTOR" },
                    { "db3fdcc2-fa8b-4a1c-a436-28a6132e2c32", "4", "Sales Staff", "SALES STAFF" }
                });
        }
    }
}
