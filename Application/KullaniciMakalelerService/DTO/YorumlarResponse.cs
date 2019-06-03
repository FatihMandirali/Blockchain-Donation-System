using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class YorumlarResponse
    {
        public string KullaniciResim { get; set; }
        public string KullaniciAdi { get; set; }
        public string YorumTarihi { get; set; }
        public string Yorum { get; set; }
        
    }
}
