using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class AddAllTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konular",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KonuAdi = table.Column<string>(nullable: true),
                    Resim = table.Column<string>(nullable: true),
                    Hakkinda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Bakiye = table.Column<int>(nullable: false),
                    Resim = table.Column<string>(nullable: true),
                    Biyografi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KonuYazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KonularIdi = table.Column<int>(nullable: false),
                    KullanicilarIdi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonuYazarlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KonuYazarlar_Konular_KonularIdi",
                        column: x => x.KonularIdi,
                        principalTable: "Konular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KonuYazarlar_Kullanicilar_KullanicilarIdi",
                        column: x => x.KullanicilarIdi,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Makaleler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KonuIdi = table.Column<int>(nullable: false),
                    Baslik = table.Column<string>(nullable: true),
                    AltBaslik = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    Tarih = table.Column<string>(nullable: true),
                    KullaniciIdi = table.Column<int>(nullable: false),
                    VerilenPara = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makaleler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makaleler_Konular_KonuIdi",
                        column: x => x.KonuIdi,
                        principalTable: "Konular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makaleler_Kullanicilar_KullaniciIdi",
                        column: x => x.KullaniciIdi,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MakalelerIdi = table.Column<int>(nullable: false),
                    YapilanYorum = table.Column<string>(nullable: true),
                    YapilanTarih = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Makaleler_MakalelerIdi",
                        column: x => x.MakalelerIdi,
                        principalTable: "Makaleler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KonuYazarlar_KonularIdi",
                table: "KonuYazarlar",
                column: "KonularIdi");

            migrationBuilder.CreateIndex(
                name: "IX_KonuYazarlar_KullanicilarIdi",
                table: "KonuYazarlar",
                column: "KullanicilarIdi");

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_KonuIdi",
                table: "Makaleler",
                column: "KonuIdi");

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_KullaniciIdi",
                table: "Makaleler",
                column: "KullaniciIdi");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_MakalelerIdi",
                table: "Yorumlar",
                column: "MakalelerIdi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KonuYazarlar");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Makaleler");

            migrationBuilder.DropTable(
                name: "Konular");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
