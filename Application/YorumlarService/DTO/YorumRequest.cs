using System;
using System.Collections.Generic;
using System.Text;

namespace Application.YorumlarService.DTO
{
   public class YorumRequest
    {
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Mesaj { get; set; }
        public string Slug { get; set; }
    }
}
