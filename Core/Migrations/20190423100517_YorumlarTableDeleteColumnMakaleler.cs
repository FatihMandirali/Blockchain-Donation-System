using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class YorumlarTableDeleteColumnMakaleler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Makaleler_MakalelerIdi",
                table: "Yorumlar");

            migrationBuilder.RenameColumn(
                name: "MakalelerIdi",
                table: "Yorumlar",
                newName: "KullanicilarIdi");

            migrationBuilder.RenameIndex(
                name: "IX_Yorumlar_MakalelerIdi",
                table: "Yorumlar",
                newName: "IX_Yorumlar_KullanicilarIdi");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullanicilarIdi",
                table: "Yorumlar",
                column: "KullanicilarIdi",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullanicilarIdi",
                table: "Yorumlar");

            migrationBuilder.RenameColumn(
                name: "KullanicilarIdi",
                table: "Yorumlar",
                newName: "MakalelerIdi");

            migrationBuilder.RenameIndex(
                name: "IX_Yorumlar_KullanicilarIdi",
                table: "Yorumlar",
                newName: "IX_Yorumlar_MakalelerIdi");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Makaleler_MakalelerIdi",
                table: "Yorumlar",
                column: "MakalelerIdi",
                principalTable: "Makaleler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
