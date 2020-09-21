using Microsoft.EntityFrameworkCore.Migrations;

namespace the_third_cms_api.Migrations
{
    public partial class Url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "CmsItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "CmsItems");
        }
    }
}
