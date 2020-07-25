using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class WebstieConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "websiteConfigurations",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_websiteConfigurations", x => x.Key);
                });
            migrationBuilder.InsertData("websiteConfigurations",new string[2] { "Key","Value"},new string[2] { "CompanyName",""});
            migrationBuilder.InsertData("websiteConfigurations",new string[2] { "Key","Value"},new string[2] { "FooterNote",""});
            migrationBuilder.InsertData("websiteConfigurations",new string[2] { "Key","Value"},new string[2] { "AdminUser","default"});
            migrationBuilder.InsertData("websiteConfigurations",new string[2] { "Key","Value"},new string[2] { "AdminPassword", "change"});
            migrationBuilder.InsertData("websiteConfigurations",new string[2] { "Key","Value"},new string[2] { "AdminEmail", ""});
            migrationBuilder.InsertData("websiteConfigurations",new string[2] { "Key","Value"},new string[2] { "AdminMobile", ""});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "websiteConfigurations");
        }
    }
}
