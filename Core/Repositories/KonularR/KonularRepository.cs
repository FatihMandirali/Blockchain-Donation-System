using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.KonularR
{
   public class KonularRepository : Repository<Konular>, IKonularRepository
    {
        public KonularRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
