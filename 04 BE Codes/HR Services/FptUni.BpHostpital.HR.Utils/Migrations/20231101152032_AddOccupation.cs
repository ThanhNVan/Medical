using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FptUni.BpHostpital.HR.Utils.Migrations
{
    public partial class AddOccupation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OccupationId",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_OccupationId",
                table: "User",
                column: "OccupationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Occupation_OccupationId",
                table: "User",
                column: "OccupationId",
                principalTable: "Occupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Occupation_OccupationId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropIndex(
                name: "IX_User_OccupationId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "User");
        }
    }
}
