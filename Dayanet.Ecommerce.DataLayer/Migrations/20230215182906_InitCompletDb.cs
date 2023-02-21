using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dayanet.Ecommerce.DataLayer.Migrations
{
    public partial class InitCompletDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_FinanceCosts_FinanceCosteId",
                table: "Finances");

            migrationBuilder.DropIndex(
                name: "IX_Finances_FinanceCosteId",
                table: "Finances");

            migrationBuilder.RenameColumn(
                name: "FinanceCosteId",
                table: "Finances",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "IsShow",
                table: "Comments",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CategoryAttributes",
                newName: "AttributeName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCustomerComment",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FinanceCosteId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageCoverPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSotialProduct",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShowCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomepage",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ProductGalleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PossitionNameFA",
                table: "Possitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProssitionNameEN",
                table: "Possitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserAddressId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProductPrice",
                table: "OrderDetailes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetailes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumProductPrice",
                table: "OrderDetailes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSellDate",
                table: "Inventories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Authority",
                table: "Finances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Finances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPay",
                table: "Finances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Finances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RefId",
                table: "Finances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CostNumber",
                table: "FinanceCosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FinanceCosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "BrowserId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SumProducts",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "AttributeValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "AttributeValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FinanceCosteId",
                table: "Products",
                column: "FinanceCosteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserAddress_UserAddressId",
                table: "Orders",
                column: "UserAddressId",
                principalTable: "UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FinanceCosts_FinanceCosteId",
                table: "Products",
                column: "FinanceCosteId",
                principalTable: "FinanceCosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserAddress_UserAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FinanceCosts_FinanceCosteId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_Products_FinanceCosteId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "AllowCustomerComment",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FinanceCosteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageCoverPath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsSotialProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShowCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShowOnHomepage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ProductGalleries");

            migrationBuilder.DropColumn(
                name: "PossitionNameFA",
                table: "Possitions");

            migrationBuilder.DropColumn(
                name: "ProssitionNameEN",
                table: "Possitions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "OrderDetailes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetailes");

            migrationBuilder.DropColumn(
                name: "SumProductPrice",
                table: "OrderDetailes");

            migrationBuilder.DropColumn(
                name: "LastSellDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Authority",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "CostNumber",
                table: "FinanceCosts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FinanceCosts");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BrowserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "SumProducts",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AttributeValues");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Finances",
                newName: "FinanceCosteId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Comments",
                newName: "IsShow");

            migrationBuilder.RenameColumn(
                name: "AttributeName",
                table: "CategoryAttributes",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_FinanceCosteId",
                table: "Finances",
                column: "FinanceCosteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_FinanceCosts_FinanceCosteId",
                table: "Finances",
                column: "FinanceCosteId",
                principalTable: "FinanceCosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
