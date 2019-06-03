using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
   public class Reklamlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Resim { get; set; }
        public string Tarih { get; set; }
        public string AdSoyad { get; set; }
        public string Baslik { get; set; }
        public string Slug { get; set; }
        public int Tur { get; set; }
        public int YayinKalkisTarih { get; set; }
        public bool YayinOnay { get; set; }
    }
}
