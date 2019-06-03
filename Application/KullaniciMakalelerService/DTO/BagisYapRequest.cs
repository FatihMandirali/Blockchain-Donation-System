using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class BagisYapRequest
    {
        public string KullaniciAdi { get; set; }
        public float BagisTutari { get; set; }
        public string YapilanMakale { get; set; }
        public int Tl { get; set; }
    }
}
