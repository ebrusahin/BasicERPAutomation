using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.Model
{
    public class SatislarModel
    {
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int UrunAdet { get; set; }
        public Nullable<int> MusteriID { get; set; }
        public string UrunAciklama { get; set; }
        public Nullable<System.DateTime> SatisDate { get; set; }

    }
}
