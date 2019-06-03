using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
  public class YoneticiAdminBlogListResponse
    {
        public string Resim { get; set; }
        public string KonuAd { get; set; }
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }
        public string KullaniciAdi { get; set; }
        public int KazandigiPara { get; set; }
        public string Tarih { get; set; }
        public int Id { get; set; }
    }
}
