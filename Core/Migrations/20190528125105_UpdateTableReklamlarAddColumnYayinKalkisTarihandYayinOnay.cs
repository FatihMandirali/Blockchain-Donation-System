using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class UpdateTableReklamlarAddColumnYayinKalkisTarihandYayinOnay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YayinKalkisTarih",
                table: "Reklamlar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "YayinOnay",
                table: "Reklamlar",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YayinKalkisTarih",
                table: "Reklamlar");

            migrationBuilder.DropColumn(
                name: "YayinOnay",
                table: "Reklamlar");
        }
    }
}
