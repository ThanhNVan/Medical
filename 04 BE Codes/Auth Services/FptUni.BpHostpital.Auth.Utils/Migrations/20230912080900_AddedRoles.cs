using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptUni.BpHostpital.Auth.Utils.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57d1ebf5-814f-4cc3-8e60-39fdb51743b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d8d34c2-6829-4040-9022-b75d599b84ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6116fefc-0eca-46ec-b699-4dfb051e98e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd6d639-d8c0-4773-9636-ae8fe9256ce5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af64526e-07f4-4ed0-9326-a78fd9455eab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e852c2f5-83a1-4f67-989e-da8fc810e192");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd490f04-12e5-4631-8adc-49f514e03dbe");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57d1ebf5-814f-4cc3-8e60-39fdb51743b6", "4", "Sales Staff", "Sales Staff" },
                    { "5d8d34c2-6829-4040-9022-b75d599b84ba", "3", "HR Staff", "Human Resource Staff" },
                    { "6116fefc-0eca-46ec-b699-4dfb051e98e1", "6", "General Director", "General Director" },
                    { "8dd6d639-d8c0-4773-9636-ae8fe9256ce5", "3", "HR Manager", "Human Resource Manager" },
                    { "af64526e-07f4-4ed0-9326-a78fd9455eab", "5", "Sales Manager", "Sales Manager" },
                    { "e852c2f5-83a1-4f67-989e-da8fc810e192", "2", "Department Director", "Department Director" },
                    { "fd490f04-12e5-4631-8adc-49f514e03dbe", "1", "Admin", "Administrator" }
                });
        }
    }
}
