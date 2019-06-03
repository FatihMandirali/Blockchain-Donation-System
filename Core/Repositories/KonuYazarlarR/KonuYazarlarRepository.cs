using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.KonuYazarlarR
{
   public class KonuYazarlarRepository : Repository<KonuYazarlar>, IKonuYazarlarRepository
    {
        public KonuYazarlarRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
