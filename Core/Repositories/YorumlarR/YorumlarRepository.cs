using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.YorumlarR
{
   public class YorumlarRepository : Repository<Yorumlar>, IYorumlarRepository
    {
        public YorumlarRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
