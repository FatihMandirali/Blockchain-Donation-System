using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class YorumlarTableAddColumnOnaylanma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Onaylanma",
                table: "Yorumlar",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Onaylanma",
                table: "Yorumlar");
        }
    }
}
