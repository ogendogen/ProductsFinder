using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RemoveTagRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Products",
                type: "TEXT",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Products",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
