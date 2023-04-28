using aslanbeyjetentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aslanbeyjetdata.Abstract
{
    public interface IGuzergahRepository:IRepository<Guzergah>
    {
        string GetNereden(string nereden);
        string GetNereye(string nereye);
        List<Guzergah> GetYolculuk(string nereden, string nereye);
        int GetGuzergahByBslBts(string basl, string gz1, string gz2, string gz3, string bts);
        Guzergah GetGuzergahDetails(int id);
        
        
    }
}
