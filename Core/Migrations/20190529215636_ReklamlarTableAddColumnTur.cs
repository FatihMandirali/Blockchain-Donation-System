using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class ReklamlarTableAddColumnTur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tur",
                table: "Reklamlar",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tur",
                table: "Reklamlar");
        }
    }
}
