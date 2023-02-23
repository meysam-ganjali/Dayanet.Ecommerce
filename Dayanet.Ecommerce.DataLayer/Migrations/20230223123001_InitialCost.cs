using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dayanet.Ecommerce.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCostTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "UpdateedDate",
                table: "Costs");

            migrationBuilder.RenameColumn(
                name: "CostNumber",
                table: "Costs",
                newName: "CostTypeId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CostTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مالیات" },
                    { 2, "هزینه پست" }
                });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "Amount", "CostTypeId" },
                values: new object[,]
                {
                    { 1, 9, 1 },
                    { 2, 1500, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_CostTypeId",
                table: "Costs",
                column: "CostTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostTypes_CostTypeId",
                table: "Costs",
                column: "CostTypeId",
                principalTable: "CostTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostTypes_CostTypeId",
                table: "Costs");

            migrationBuilder.DropTable(
                name: "CostTypes");

            migrationBuilder.DropIndex(
                name: "IX_Costs_CostTypeId",
                table: "Costs");

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Costs");

            migrationBuilder.RenameColumn(
                name: "CostTypeId",
                table: "Costs",
                newName: "CostNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Costs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "Costs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Costs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateedDate",
                table: "Costs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    UpdateedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCostTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCostTypes_Costs_CostId",
                        column: x => x.CostId,
                        principalTable: "Costs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCostTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCostTypes_CostId",
                table: "ProductCostTypes",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCostTypes_ProductId",
                table: "ProductCostTypes",
                column: "ProductId");
        }
    }
}
