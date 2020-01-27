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
    class HelperSatisYonetimi
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

        public static List<UrunlerModel> ReturnUrunler(int ID)
        {
            List<UrunlerModel> urunler = new List<UrunlerModel>();

            using (hesapEntities he = new hesapEntities())
            {
                List<Urunler> urunlers = he.Urunler.ToList();
                foreach (var item in urunlers)
                {
                    UrunlerModel um = new UrunlerModel();
                    if (item.KategoriID == ID)
                    {
                        um.UrunAd = item.UrunAd;
                        um.SatisUcret = item.SatisUcret;
                        um.UrunDesc = item.UrunDesc;

                        um.KategoriID = item.KategoriID;
                        um.GelisUcret = item.GelisUcret;
                        um.Stok = item.Stok;
                        urunler.Add(um);
                    }
                }
            }
            return urunler;
        }
        //idye eşit olan ürünlerin adı, satış fiyatı, açıklaması gelecek

        public static List<Urunler> ReturnUrunler()
        {
            using (hesapEntities he = new hesapEntities())
            {
                return he.Urunler.ToList();
            }
        }
        public static bool AddSatislar(SatislarModel sm)
        {
            using (hesapEntities he = new hesapEntities())
            {
                var s = ConvertToSatislar(sm);
                he.Satislar.Add(s);
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static Satislar ConvertToSatislar(SatislarModel sm)
        {
            Satislar ns = new Satislar();
            ns.UrunID = sm.UrunID;
            ns.UrunAdet = sm.UrunAdet;
            ns.UrunAciklama = sm.UrunAciklama;
            ns.MusteriID = sm.MusteriID;
            ns.SatisDate = sm.SatisDate;

            return ns;
        }
        public static int FindUrunID(string ad, int kategoriID)
        {
            int urunID = 0;
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Urunler.ToList();
                foreach (var item in list)
                {
                    if (item.UrunAd.Equals(ad) && item.KategoriID.Equals(kategoriID))
                    {
                        urunID = item.UrunID;
                    }
                }
            }
            return urunID;
        }

        //public static bool UpdateUrunler(UrunlerModel um)
        //{
        //    Urunler u = new Urunler();
        //    using (hesapEntities he = new hesapEntities())
        //    {
        //        u.UrunID = um.UrunID;

        //        he.Entry(u).State = EntityState.Modified;
        //        if (he.SaveChanges() > 0)
        //        {
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //}
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
        public static string FindMusteriAd(int ID)
        {
            string musteriAd = "";
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Musteriler.ToList();
                foreach (var item in list)
                {
                    if (item.MusteriID == ID)
                    {
                        musteriAd = item.MusteriAd;
                    }
                }
            }
            return musteriAd;

        }

        public static List<UrunlerModel> MusteriyeGoreRapor(int id, DateTime value1, DateTime value2)
        {
            List<UrunlerModel> rapor = new List<UrunlerModel>();

            using (hesapEntities he = new hesapEntities())
            {
                var satislarList = he.Satislar.ToList();
                var urunlerList = ReturnUrunler();


                foreach (var item in satislarList)
                {
                    if (id == item.MusteriID)
                    {
                        UrunlerModel um = new UrunlerModel();
                        if (value1 <= item.SatisDate && value2 >= item.SatisDate)
                        {
                            um.sm.SatisDate = item.SatisDate;
                            um.sm.UrunAdet = item.UrunAdet;
                            
                            foreach (var urun in urunlerList)
                            {
                                if (urun.UrunID == item.UrunID)
                                {
                                    um.SatisUcret = urun.SatisUcret;
                                    um.UrunAd = urun.UrunAd;
                                    um.km.KategoriAd = FindKategoriAd(urun.KategoriID);
                                }
                            }
                            rapor.Add(um);
                        }

                    }
                }
                return rapor;
            }

        }
        public static List<UrunlerModel> UruneGoreRapor(int id, DateTime value1, DateTime value2)
        {
            List<UrunlerModel> rapor = new List<UrunlerModel>();

            using (hesapEntities he = new hesapEntities())
            {
                var satislarList = he.Satislar.ToList();
                var urunlerList = ReturnUrunler();


                foreach (var item in satislarList)
                {
                    if (id == item.UrunID)
                    {
                        UrunlerModel um = new UrunlerModel();
                        if (value1 <= item.SatisDate && value2 >= item.SatisDate)
                        {
                            um.sm.SatisDate = item.SatisDate;
                            um.sm.UrunAdet = item.UrunAdet;
                            um.sm.MusteriID = item.MusteriID;
                            foreach (var urun in urunlerList)
                            {
                                if (urun.UrunID == item.UrunID)
                                {
                                    um.SatisUcret = urun.SatisUcret;
                                    um.UrunAd = urun.UrunAd;
                                    um.km.KategoriAd = FindKategoriAd(urun.KategoriID);
                                }
                            }
                            rapor.Add(um);
                        }

                    }
                }
                return rapor;
            }

        }
        public static int KarZararHesapla()
        {
            int totalAlis = 0, totalSatis = 0;
          
            using (hesapEntities he = new hesapEntities())
            {
                var satisList = he.Satislar.ToList();
                var urunList = he.Urunler.ToList();

                foreach (var item in satisList)
                {
                    UrunlerModel um = new UrunlerModel();
                    um.UrunID = item.UrunID;
                    um.sm.UrunAdet = item.UrunAdet;
                    foreach (var itemUrun in urunList)
                    {
                        if (um.UrunID==itemUrun.UrunID)
                        {
                            int adet = um.sm.UrunAdet;
                            int satis = itemUrun.SatisUcret;
                            int alis = itemUrun.GelisUcret;
                            totalAlis = adet * alis;
                            totalSatis = adet * satis;
                        }
                    }
                }
                int fark = totalSatis - totalAlis;
                return fark;
            }
        
        }

    }
}
