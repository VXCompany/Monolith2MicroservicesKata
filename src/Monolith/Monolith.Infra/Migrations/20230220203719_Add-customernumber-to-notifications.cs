using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Addcustomernumbertonotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                schema: "notification",
                table: "Notification",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                schema: "notification",
                table: "Notification");
        }
    }
}
