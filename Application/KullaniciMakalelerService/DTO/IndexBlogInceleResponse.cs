using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class IndexBlogInceleResponse
    {
        public string Resim { get; set; }
        public string Baslik { get; set; }
        public string Tarih { get; set; }
        public string KonuAdi { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }
        public string KullaniciResim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Biyografi { get; set; }
        public int YorumSayisi { get; set; }
        public float CoinSayisi { get; set; }
        public List<YorumlarResponse> liste { get; set; }
    }
}
