using CariHesap.Entity;
using CariHesap.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.Helper
{
    class HelperMusteriler
    {
        public static List<MusterilerModel> MusterilerAsList()
        {
            List<MusterilerModel> musteriList = new List<MusterilerModel>();
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Musteriler.ToList();
                foreach (Musteriler item in list)
                {
                    MusterilerModel mm = new MusterilerModel();
                    mm.MusteriID = item.MusteriID;
                    mm.MusteriAd = item.MusteriAd;
                    mm.MusteriSoyad = item.MusteriSoyad;
                    mm.Telefon = item.Telefon;
                    mm.Adres = item.Adres;
                    musteriList.Add(mm);
                }
            }

            return musteriList;

        }
       
        public static bool AddMusteri(MusterilerModel m)
        {
            using (hesapEntities he = new hesapEntities())
            {
                Musteriler musteri = ConvertToMusteriler(m);
                he.Musteriler.Add(musteri);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool DeleteMusteri(int ID)
        {
            using (hesapEntities he = new hesapEntities())
            {
                var s = he.Musteriler.Find(ID);
                he.Musteriler.Remove(s);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static int FindMusteri(MusterilerModel m)
        {
            int musteriID = 0;
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Musteriler.ToList();
                foreach (var item in list)
                {
                    if (m.MusteriAd.Equals(item.MusteriAd) && m.MusteriSoyad.Equals(item.MusteriSoyad) && 
                        m.Telefon.Equals(item.Telefon) && m.Adres.Equals(item.Adres))
                    {
                        musteriID= item.MusteriID;
                    }
                }
            }

            return musteriID;
        }

        public static bool UpdateMusteri(MusterilerModel mm)
        {         
            var musteri = ConvertToMusteriler(mm);
            using (hesapEntities he = new hesapEntities())
            {
                he.Entry(musteri).State = EntityState.Modified;
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static Musteriler ConvertToMusteriler(MusterilerModel mm)
        {
            Musteriler m = new Musteriler();
            m.MusteriID = mm.MusteriID;
            m.MusteriAd = mm.MusteriAd;
            m.MusteriSoyad = mm.MusteriSoyad;
            m.Telefon = mm.Telefon;
            m.Adres = mm.Adres;

            return m;
        }
    }
}
