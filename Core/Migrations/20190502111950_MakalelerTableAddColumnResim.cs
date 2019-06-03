using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class MakalelerTableAddColumnResim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "Makaleler",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resim",
                table: "Makaleler");
        }
    }
}
