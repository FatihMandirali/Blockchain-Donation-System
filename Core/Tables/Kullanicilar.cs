using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
  public  class Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public float Bakiye { get; set; }
        public string Resim { get; set; }
        public string Biyografi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        
    }
}
