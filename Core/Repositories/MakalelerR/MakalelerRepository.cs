using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.MakalelerR
{
   public class MakalelerRepository : Repository<Makaleler>, IMakalelerRepository
    {
        public MakalelerRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
