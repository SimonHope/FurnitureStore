using Microsoft.EntityFrameworkCore.Migrations;

namespace FurnitureStore.Migrations
{
    public partial class AddingtheBaskettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "stockId",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stockId",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Baskets",
                type: "TEXT",
                nullable: true);
        }
    }
}
