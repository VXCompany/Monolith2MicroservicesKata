using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Addappsourcetomonolith : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                schema: "warehouse",
                table: "StockItem",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                table: "PickOrderLine",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                schema: "warehouse",
                table: "PickOrder",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                table: "OrderLine",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                schema: "ordering",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                table: "CartItem",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSource",
                schema: "shoppingcart",
                table: "Cart",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                schema: "warehouse",
                table: "StockItem");

            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                table: "PickOrderLine");

            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                schema: "warehouse",
                table: "PickOrder");

            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                schema: "ordering",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ApplicationSource",
                schema: "shoppingcart",
                table: "Cart");
        }
    }
}
