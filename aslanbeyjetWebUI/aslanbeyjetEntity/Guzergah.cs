using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aslanbeyjetentity
{
    public class Guzergah
    {
        
        public int GuzergahId { get; set; }
        public string Baslangic { get; set; }
        public string Bitis { get; set; }

        public string Tarih { get; set; }
        public string Saat { get; set; }
        public string ImageUrl { get; set; }
        public double Fiyat { get; set; }

        
        public List<Bilet> Bilets { get; set; }
    }
}
