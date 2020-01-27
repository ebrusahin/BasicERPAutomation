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
    class HelperKategoriler
    {
        public static int FindKategoriID(string ad)
        {
            int id = 0;
            using (hesapEntities he = new hesapEntities())
            {
                var kategoriler = he.Kategoriler.ToList();
                foreach (var item in kategoriler)
                {
                    if (item.KategoriAd.Equals(ad))
                    {
                        id = item.KategoriID;
                    }
                }
            }
            return id;
        }
        public static string FindKategoriAd(int ID)
        {
            string kategori = "";
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Kategoriler.ToList();
                foreach (var item in list)
                {
                    if (item.KategoriID == ID)
                    {
                        kategori = item.KategoriAd;
                    }
                }
            }
            return kategori;
        }

        public static bool AddKategori(KategorilerModel km)
        {
            var f = ConvertToKategoriler(km);
            using (hesapEntities he = new hesapEntities())
            {
                he.Kategoriler.Add(f);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool UpdateKategori(KategorilerModel km)
        {
            var k = ConvertToKategoriler(km);
            using (hesapEntities he = new hesapEntities())
            {
                he.Entry(k).State = EntityState.Modified;
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool DeleteKategori(int ID)
        {
            using (hesapEntities he = new hesapEntities())
            {
                var id = he.Kategoriler.Find(ID);
                he.Kategoriler.Remove(id);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
                
            }
        }
        public static Kategoriler ConvertToKategoriler(KategorilerModel km)
        {
            Kategoriler k = new Kategoriler();
            k.KategoriID = km.KategoriID;
            k.KategoriAd = km.KategoriAd;
            k.KategoriDesc = km.KategoriDesc;

            return k;
        }
        public static List<KategorilerModel> KategorilerAsList()
        {
            List<KategorilerModel> km = new List<KategorilerModel>();
            using (hesapEntities he = new hesapEntities())
            {
                var klist = he.Kategoriler.ToList();
                foreach (var item in klist)
                {
                    KategorilerModel k = new KategorilerModel();
                    k.KategoriAd = item.KategoriAd;
                    k.KategoriDesc = item.KategoriDesc;
                    k.KategoriID = item.KategoriID;

                    km.Add(k);
                }
            }
            return km;
        }

    }
}
