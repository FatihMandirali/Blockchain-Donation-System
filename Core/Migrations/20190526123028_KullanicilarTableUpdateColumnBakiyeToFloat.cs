using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class KullanicilarTableUpdateColumnBakiyeToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Bakiye",
                table: "Kullanicilar",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Bakiye",
                table: "Kullanicilar",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
