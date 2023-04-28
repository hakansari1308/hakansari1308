using aslanbeyjetentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aslanbeyjetdata.Abstract
{
    public interface ISehirRepository:IRepository<Sehir>
    {
        string sehirad();
    }
}
