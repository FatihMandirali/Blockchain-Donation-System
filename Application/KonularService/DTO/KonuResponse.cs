using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KonularService.DTO
{
   public class KonuResponse
    {
        public int Id { get; set; }
        public string KonuAdi { get; set; }
        public string Resim { get; set; }
        public string Hakkinda { get; set; }
    }
}
