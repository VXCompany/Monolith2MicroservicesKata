using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ProductCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                schema: "warehouse",
                table: "StockItem",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                schema: "warehouse",
                table: "StockItem");
        }
    }
}
