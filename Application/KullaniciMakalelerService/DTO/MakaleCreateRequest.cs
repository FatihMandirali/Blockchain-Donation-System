using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class MakaleCreateRequest
    {
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }
        public string Resim { get; set; }
        public string KullaniciAdi { get; set; }
        public int KonuIdi { get; set; }
    }
}
