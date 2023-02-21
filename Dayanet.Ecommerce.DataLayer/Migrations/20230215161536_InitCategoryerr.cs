using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dayanet.Ecommerce.DataLayer.Migrations
{
    public partial class InitCategoryerr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possitions_Possitions_PossitionId",
                table: "Possitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Possitions_PossitionId",
                table: "Possitions");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PossitionId",
                table: "Possitions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossitionId",
                table: "Possitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Possitions_PossitionId",
                table: "Possitions",
                column: "PossitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Possitions_Possitions_PossitionId",
                table: "Possitions",
                column: "PossitionId",
                principalTable: "Possitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
