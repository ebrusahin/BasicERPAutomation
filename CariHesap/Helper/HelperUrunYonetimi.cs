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
    class HelperUrunYonetimi
    {
        public static List<UrunlerModel> UrunlerAsList()
        {
            List<UrunlerModel> urunlerList = new List<UrunlerModel>();
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Urunler.ToList();
                var kategoriList = he.Kategoriler.ToList();
                foreach (var item in list)
                {
                    UrunlerModel um = new UrunlerModel();
                    um.UrunID = item.UrunID;
                    um.UrunAd = item.UrunAd;
                    um.KategoriID = item.KategoriID;                 
                    um.GelisUcret = item.GelisUcret;
                    um.SatisUcret = item.SatisUcret;
                    um.Stok = item.Stok;
                    um.UrunDesc = item.UrunDesc;
                    foreach (var kategori in kategoriList)
                    {
                        if (item.KategoriID==kategori.KategoriID)
                        {
                            um.km.KategoriAd = kategori.KategoriAd;
                            um.km.KategoriDesc = kategori.KategoriDesc;
                        } 
                    } //kategori adının ve açıklamasının dahil edilmesi

                    urunlerList.Add(um);
                    
                }
            }
            return urunlerList;

        } 
        public static List<UrunlerModel> KategorilerAsList()
        {
            List<UrunlerModel> kategoriAdlar = new List<UrunlerModel>();
            using (hesapEntities he = new hesapEntities())
            {
                var kategoriler = he.Kategoriler.ToList();
                foreach (var item in kategoriler)
                {
                    UrunlerModel um = new UrunlerModel();
                    um.km.KategoriAd = item.KategoriAd;
                    um.km.KategoriID = item.KategoriID;
                    um.km.KategoriDesc = item.KategoriDesc;
                    kategoriAdlar.Add(um);
                }
            }
            return kategoriAdlar;
        }
        public static int FindUrun(UrunlerModel um)
        {
            int urunID = 0;
            using (hesapEntities he = new hesapEntities())
            {
                var urunList = he.Urunler.ToList();

                foreach (var item in urunList)
                {
                    if (um.UrunAd.Equals(item.UrunAd) && um.GelisUcret.Equals(item.GelisUcret) && um.SatisUcret.Equals(item.SatisUcret))
                    {
                        urunID = item.UrunID;
                    } 
                }
            }
            return urunID;
        }
        public static bool DeleteUrun(int ID)
        {
            using (hesapEntities he = new hesapEntities())
            {
                var s = he.Urunler.Find(ID);
                he.Urunler.Remove(s);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool AddUrun(UrunlerModel um)
        {
            var u = ConvertToUrunler(um);
            using (hesapEntities he = new hesapEntities())
            {
                he.Urunler.Add(u);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool UpdateUrun(UrunlerModel um)
        {
            var urun = ConvertToUrunler(um);
            using (hesapEntities he = new hesapEntities())
            {
                he.Entry(urun).State = EntityState.Modified;
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static Urunler ConvertToUrunler(UrunlerModel um)
        {
            Urunler yeniUrun = new Urunler();
            yeniUrun.UrunID = um.UrunID;
            yeniUrun.KategoriID = um.KategoriID;
            yeniUrun.UrunAd = um.UrunAd;
            yeniUrun.GelisUcret = um.GelisUcret;
            yeniUrun.SatisUcret = um.SatisUcret;
            yeniUrun.Stok = um.Stok;
            yeniUrun.UrunDesc = um.UrunDesc;
            return yeniUrun;
        }
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
    }
}
