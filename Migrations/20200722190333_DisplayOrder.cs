using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class DisplayOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Products",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Paragraph",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Pages",
                nullable: false,
                defaultValue: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Paragraph");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Pages");
        }
    }
}
