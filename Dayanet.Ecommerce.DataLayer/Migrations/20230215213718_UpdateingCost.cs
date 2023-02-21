using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dayanet.Ecommerce.DataLayer.Migrations
{
    public partial class UpdateingCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FinanceCosts_FinanceCosteId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FinanceCosts");

            migrationBuilder.DropIndex(
                name: "IX_Products_FinanceCosteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FinanceCosteId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCostTypes");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.AddColumn<int>(
                name: "FinanceCosteId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FinanceCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCosts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FinanceCosteId",
                table: "Products",
                column: "FinanceCosteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FinanceCosts_FinanceCosteId",
                table: "Products",
                column: "FinanceCosteId",
                principalTable: "FinanceCosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
