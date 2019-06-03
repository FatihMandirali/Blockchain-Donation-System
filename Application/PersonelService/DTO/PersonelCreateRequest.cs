using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PersonelService.DTO
{
   public class PersonelCreateRequest
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Tc { get; set; }
    }
}
