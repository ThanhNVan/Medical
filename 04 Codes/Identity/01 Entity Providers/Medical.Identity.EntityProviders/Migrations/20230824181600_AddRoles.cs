using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Identity.EntityProviders.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
