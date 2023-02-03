using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                schema: "warehouse",
                table: "Items");

            migrationBuilder.EnsureSchema(
                name: "shoppingcart");

            migrationBuilder.RenameTable(
                name: "Items",
                schema: "warehouse",
                newName: "Item",
                newSchema: "warehouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "warehouse",
                table: "Item",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cart",
                schema: "shoppingcart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart",
                schema: "shoppingcart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "warehouse",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                schema: "warehouse",
                newName: "Items",
                newSchema: "warehouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                schema: "warehouse",
                table: "Items",
                column: "Id");
        }
    }
}
