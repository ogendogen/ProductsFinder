using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProductNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Addon1 = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Addon2 = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Addon3 = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Addon4 = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
