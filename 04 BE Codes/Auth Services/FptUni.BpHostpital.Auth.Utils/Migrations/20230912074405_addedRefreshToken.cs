using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptUni.BpHostpital.Auth.Utils.Migrations
{
    public partial class addedRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email_UserName",
                table: "AspNetUsers",
                columns: new[] { "Email", "UserName" },
                unique: true,
                filter: "[Email] IS NOT NULL AND [UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email_UserName",
                table: "AspNetUsers");

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
        }
    }
}
