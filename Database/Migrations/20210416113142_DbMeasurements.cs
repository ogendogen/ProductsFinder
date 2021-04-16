using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class DbMeasurements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductNumber",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductNumber",
                table: "Products",
                column: "ProductNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Tag",
                table: "Products",
                column: "Tag",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductNumber",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Tag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductNumber",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
