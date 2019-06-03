using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class BlogAdListResponse
    {
        public string Baslik { get; set; }
        public int Id { get; set; }
        public string AltBaslik { get; set; }
       // public string Icerik { get; set; }
        public string Tarih { get; set; }
        public string Resim { get; set; }
        public string Slug { get; set; }
    }
}
