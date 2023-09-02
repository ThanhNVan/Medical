using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Identity.EntityProviders.Migrations
{
    public partial class addRolesAndDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: "23a437d1-4b44-48c9-b1fc-c6fd9a3b4b6b");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: "670e499b-acfa-4f32-993b-ab3fdee89b89");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: "a36e0fab-ad4b-4e2f-822e-bcb26d4f1fdd");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1110ec51-b084-4638-b170-5a49fdedd33c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3b5041b2-bfcf-410f-84a5-d7a0adf00f2b");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8c4efc0f-ac86-48e7-b16e-b57721814272");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "99cad2ed-a60f-43cf-b817-ea07cefe5dd8");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac8afc3a-5eb5-4055-8834-aa0df5c3ff6f");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c8c863d5-7778-48fd-9880-7b8e19c40dfe");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[,]
                {
                    { "7b281cf4-4ecb-4551-82f0-3981d6f3a0c4", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2437), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2439), "IT" },
                    { "956a9aaf-cfd0-481b-a006-81569c33f303", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2443), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2443), "Sales" },
                    { "fc47cfe0-42ef-4e6c-bcdd-3ee73322a4ae", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2445), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2445), "HR" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[,]
                {
                    { "0eedf519-d163-480e-9903-d63f4fe87471", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2601), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2601), "Nurse" },
                    { "1421c41b-eabc-4dbd-a270-dcdd0e3413b0", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2587), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2587), "Admin" },
                    { "15a61590-2b36-4157-b46a-e72122cae6d7", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2584), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2584), "Staff" },
                    { "22cd9bb1-e8fd-4d19-b7b5-e5b9f8765a94", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2605), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2606), "Director" },
                    { "bdb25065-340d-44fa-9e13-cc1b587a3c3a", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2591), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2591), "Doctor" },
                    { "db266e1f-71b9-4b55-8e6c-dcd9e3033651", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2589), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2589), "Manager" },
                    { "f540a20e-35da-4b57-bc74-72b48ac89767", new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2603), false, new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2603), "Pharmacist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: "7b281cf4-4ecb-4551-82f0-3981d6f3a0c4");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: "956a9aaf-cfd0-481b-a006-81569c33f303");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: "fc47cfe0-42ef-4e6c-bcdd-3ee73322a4ae");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "0eedf519-d163-480e-9903-d63f4fe87471");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1421c41b-eabc-4dbd-a270-dcdd0e3413b0");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "15a61590-2b36-4157-b46a-e72122cae6d7");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "22cd9bb1-e8fd-4d19-b7b5-e5b9f8765a94");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "bdb25065-340d-44fa-9e13-cc1b587a3c3a");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "db266e1f-71b9-4b55-8e6c-dcd9e3033651");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f540a20e-35da-4b57-bc74-72b48ac89767");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[,]
                {
                    { "23a437d1-4b44-48c9-b1fc-c6fd9a3b4b6b", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1188), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1188), "IT" },
                    { "670e499b-acfa-4f32-993b-ab3fdee89b89", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1146), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1149), "Human Resource" },
                    { "a36e0fab-ad4b-4e2f-822e-bcb26d4f1fdd", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1190), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1191), "Sales" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[,]
                {
                    { "1110ec51-b084-4638-b170-5a49fdedd33c", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1345), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1345), "Pharmacist" },
                    { "3b5041b2-bfcf-410f-84a5-d7a0adf00f2b", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1320), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1320), "Staff" },
                    { "8c4efc0f-ac86-48e7-b16e-b57721814272", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1340), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1340), "Doctor" },
                    { "99cad2ed-a60f-43cf-b817-ea07cefe5dd8", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1342), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1343), "Nurse" },
                    { "ac8afc3a-5eb5-4055-8834-aa0df5c3ff6f", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1323), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1323), "Admin" },
                    { "c8c863d5-7778-48fd-9880-7b8e19c40dfe", new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1325), false, new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1325), "Manager" }
                });
        }
    }
}
