using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService.DTO
{
   public class BlogPaylasimResponse
    {
        public string Resim { get; set; }
        public string KonuAdi { get; set; }
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }
        public string Tarih { get; set; }
        public float KazanilanPara { get; set; }
        public int Id { get; set; }
    }
}
