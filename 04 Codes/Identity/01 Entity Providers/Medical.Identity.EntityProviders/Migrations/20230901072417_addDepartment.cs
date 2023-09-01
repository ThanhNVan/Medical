using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Identity.EntityProviders.Migrations
{
    public partial class addDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId_UserId",
                table: "UserRole");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "423c5327-7f6c-4b39-9f7e-265d9ed53d43");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "54759cb2-0b36-4b39-a1a6-1eb8114a83f6");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "87896958-50b4-46a6-ba33-535338382147");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8973e26f-0c5e-4834-b7ce-eec4f8012bd1");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ab111e2d-1a3c-40bc-b709-09b1c42f557f");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b5084094-63db-4d74-adb7-276e5b59636e");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "d022a2f7-1409-46f0-9f91-722af730dd66");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f2c45945-28ab-44c8-9163-f0ff3ff29b60");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "fe89a909-b523-43d2-9b93-179e49f94bcf");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "UserRole",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_DepartmentId",
                table: "UserRole",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId_UserId_DepartmentId",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Department_DepartmentId",
                table: "UserRole",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Department_DepartmentId",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_DepartmentId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId_UserId_DepartmentId",
                table: "UserRole");

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

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "UserRole");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[,]
                {
                    { "423c5327-7f6c-4b39-9f7e-265d9ed53d43", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(345), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(346), "Nurse" },
                    { "54759cb2-0b36-4b39-a1a6-1eb8114a83f6", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(322), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(322), "Human Resource" },
                    { "87896958-50b4-46a6-ba33-535338382147", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(334), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(334), "Sales" },
                    { "8973e26f-0c5e-4834-b7ce-eec4f8012bd1", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(327), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(328), "Staff" },
                    { "ab111e2d-1a3c-40bc-b709-09b1c42f557f", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(332), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(332), "Manager" },
                    { "b5084094-63db-4d74-adb7-276e5b59636e", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(347), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(348), "Pharmacist" },
                    { "d022a2f7-1409-46f0-9f91-722af730dd66", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(325), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(325), "IT" },
                    { "f2c45945-28ab-44c8-9163-f0ff3ff29b60", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(330), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(330), "Admin" },
                    { "fe89a909-b523-43d2-9b93-179e49f94bcf", new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(336), false, new DateTime(2023, 8, 24, 18, 16, 0, 371, DateTimeKind.Utc).AddTicks(336), "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId_UserId",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                unique: true);
        }
    }
}
