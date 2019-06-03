using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class MakalelerTableAddColumnPaylasilma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paylasilma",
                table: "Makaleler",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paylasilma",
                table: "Makaleler");
        }
    }
}
