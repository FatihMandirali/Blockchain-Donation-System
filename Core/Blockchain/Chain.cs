using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Blockchain
{
   public class Chain
    {
        public int index { get; set; }
        public string previous_hash { get; set; }
        public int proof { get; set; }
        public string timestamp { get; set; }
        public List<Transactions> transactions { get; set; }
    }
}
