using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class YorumlarTableAddColumnMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Yorumlar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Yorumlar");
        }
    }
}
