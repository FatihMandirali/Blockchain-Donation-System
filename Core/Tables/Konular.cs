using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
   public class Konular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string KonuAdi { get; set; }
        public string Resim { get; set; }
        public string Hakkinda { get; set; }
        public string Slug { get; set; }
    }
}
