using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
   public class Yorumlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("MakalelerId")]
        public int MakalelerIdi { get; set; }
        public virtual Makaleler MakalelerId { get; set; }

        //[ForeignKey("KullanicilarId")]
      //  public int KullanicilarIdi { get; set; }
        public  string AdSoyad { get; set; }

        public string YapilanYorum { get; set; }
        public string YapilanTarih { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool Onaylanma { get; set; }

       
    }
}
