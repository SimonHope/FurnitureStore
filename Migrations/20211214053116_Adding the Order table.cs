using Microsoft.EntityFrameworkCore.Migrations;

namespace FurnitureStore.Migrations
{
    public partial class AddingtheOrdertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "stockId",
                table: "Baskets",
                newName: "StockId");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StockName",
                table: "Baskets",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "StockName",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Baskets",
                newName: "stockId");
        }
    }
}
