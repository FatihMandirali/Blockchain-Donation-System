using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.BegenilerR
{
   public class BegenilerRepository : Repository<Begeniler>, IBegenilerRepository
    {
        public BegenilerRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
