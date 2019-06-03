using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class ReklamlarTableAddColumnSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Reklamlar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Reklamlar");
        }
    }
}
