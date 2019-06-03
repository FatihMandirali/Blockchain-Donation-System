using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class AddTableReklamlar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tc",
                table: "Personeller",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Reklamlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resim = table.Column<string>(nullable: true),
                    Tarih = table.Column<string>(nullable: true),
                    AdSoyad = table.Column<string>(nullable: true),
                    Baslik = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reklamlar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reklamlar");

            migrationBuilder.AlterColumn<string>(
                name: "Tc",
                table: "Personeller",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
