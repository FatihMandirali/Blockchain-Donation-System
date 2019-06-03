using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
   public class Makaleler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KonuId")]
        public int KonuIdi { get; set; }
        public virtual Konular KonuId { get; set; }

        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }
        public string Tarih { get; set; }
        public string Resim { get; set; }
        public string Slug { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciIdi { get; set; }
        public virtual Kullanicilar KullaniciId { get; set; }

        public int VerilenPara { get; set; }
        public bool Paylasilma { get; set; }
        
    }
}
