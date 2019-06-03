using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class KonularTableAddColumnSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Konular",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Konular");
        }
    }
}
