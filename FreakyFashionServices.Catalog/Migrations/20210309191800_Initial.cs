using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashionServices.Catalog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "AvailableStock", "Description", "Name", "Price" },
                values: new object[] { 1, 12, "Lorem ipsum dolor", "Black T-Shirt", 299 });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "AvailableStock", "Description", "Name", "Price" },
                values: new object[] { 2, 10, "Lorem ipsum dolor", "White T-Shirt", 299 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
