using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
   public class KonuYazarlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KonularId")]
        public int KonularIdi { get; set; }
        public virtual Konular KonularId { get; set; }

        [ForeignKey("KullanicilarId")]
        public int KullanicilarIdi { get; set; }
        public virtual Kullanicilar KullanicilarId { get; set; }
    }
}
