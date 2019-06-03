using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class KullanicilarandPersonellerTableAddColumnKullaniciAdiSifre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Personeller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Personeller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Kullanicilar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Kullanicilar");
        }
    }
}
