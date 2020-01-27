using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.Model
{
    public class UrunlerModel
    {
        public int UrunID { get; set; }
        public int KategoriID { get; set; }
        public string UrunAd { get; set; }
        public int GelisUcret { get; set; }
        public int SatisUcret { get; set; }
        public Nullable<int> Stok { get; set; }
        public string UrunDesc { get; set; }

        public KategorilerModel km = new KategorilerModel();
        public SatislarModel sm = new SatislarModel();
    }
}
