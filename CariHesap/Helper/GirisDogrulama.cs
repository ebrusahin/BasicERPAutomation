using CariHesap.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.Helper
{
    class GirisDogrulama
    {
        public static int Giris(string kullaniciAd, string sifre)
        {
            using (hesapEntities he = new hesapEntities())
            {
                var kullanicilar = he.Kullanicilar.ToList();
                foreach (var item in kullanicilar)
                {
                    if (item.KullaniciAd == kullaniciAd && item.KullaniciSifre.ToString() == sifre)
                    {
                        return 0;
                    }
                    //else if (item.KullaniciSifre != sifre)
                    //{
                    //    return 1;

                    //}
                    //else if (item.KullaniciAd != kullaniciAd)
                    //{
                    //    return 2;
                    //}                   
                }
            }

            return 3;
        }

        public static Kullanicilar SifreDegistir(string kAd, string eSifre, string ySifre)
        {
            Kullanicilar k = new Kullanicilar();
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Kullanicilar.ToList();
                foreach (var item in list)
                {
                    if (item.KullaniciAd==kAd)
                    {
                        if (item.KullaniciSifre==eSifre)
                        {
                            k.KullaniciAd = kAd;
                            k.KullaniciSifre = ySifre;
                            k.KullaniciID = item.KullaniciID;
                        }
                    }
                }
            }
            return k;
        }

        public static bool UpdateKullanicilar(Kullanicilar kk)
        {
            using (hesapEntities he = new hesapEntities())
            {
                he.Entry(kk).State = EntityState.Modified;
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

    }
}
