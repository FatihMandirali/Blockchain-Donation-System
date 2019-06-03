using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class BlogListResponse
    {
        public string Resim { get; set; }
        public string KonuAdi { get; set; }
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Slug { get; set; }
        public int Id { get; set; }
    }
}
