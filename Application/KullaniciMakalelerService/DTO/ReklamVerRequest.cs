using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class ReklamVerRequest
    {
        public int BlogId { get; set; }
        public int Tarife { get; set; }
        public string KullaniciAdi { get; set; }
    }
}
