using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class YoneticiBagisListResponse
    {
        public string KullaniciAdi { get; set; }
        public string Makale { get; set; }
        public int Tutar { get; set; }
        public string YapanKisi { get; set; }
    }
}
