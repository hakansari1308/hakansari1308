using Aslanbeyjetdata.Abstract;
using aslanbeyjetentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aslanbeyjetdata.Concrete
{
    public class EfCoreSehirRepository : EfCoreGenericRepository<Sehir, BiletContext>, ISehirRepository
    {
        public string sehirad()
        {
            throw new NotImplementedException();
        }
    }
}
