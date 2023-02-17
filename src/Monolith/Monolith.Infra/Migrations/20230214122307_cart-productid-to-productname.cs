using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infra.Migrations
{
    /// <inheritdoc />
    public partial class cartproductidtoproductname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartItem");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "CartItem",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "CartItem");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "CartItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
