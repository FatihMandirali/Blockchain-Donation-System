using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.KullanicilarR
{
   public class KullanicilarRepository : Repository<Kullanicilar>, IKullanicilarRepository
    {
        public KullanicilarRepository(BitirmeContext context) : base(context)
        {
        }
    }
}
