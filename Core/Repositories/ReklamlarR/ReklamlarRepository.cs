using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.ReklamlarR
{
   public class ReklamlarRepository : Repository<Reklamlar>, IReklamlarRepository
    {
        public ReklamlarRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
