using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.PersonellerR
{
   public class PersonelRepository : Repository<Personeller>, IPersonelRepository
    {
        public PersonelRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
