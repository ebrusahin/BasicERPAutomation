using CariHesap.Entity;
using CariHesap.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariHesap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataGridView1List(); dataGridView1.ClearSelection();
            DataGridView2List(); dataGridView2.ClearSelection();
            DataGridView5List(); dataGridView5.ClearSelection();
            ComboBox1Fill(); 
            ComboBox2Fill(); comboBox2.Enabled = false;
            ComboBox3Fill();

            button4.Enabled = false;
            button4.Enabled = false;
            button13.Enabled = false;
           

        }
        
        string mAd, mSoyad, mTel, mAdres;
        string uAd, uKategori, uAciklama; int gUcret = 0, sUcret = 0, stok = 0;
        string kAd, kAciklama;
        int musteriID = 0, kID = 0;
        List<int> cbMusteri = new List<int>(); //satış sayfasındaki müşterilerin idleri tutuluyor
        List<int> cbUrun = new List<int>(); //satış sayfasındaki ürünlerin idleri tutuluyor

        private void button3_Click(object sender, EventArgs e)  //yeni müşteri ekle
        {
            MusterilerModel yeniMusteri = new MusterilerModel();
            yeniMusteri.MusteriAd = textBox1.Text;
            yeniMusteri.MusteriSoyad = textBox2.Text;
            yeniMusteri.Telefon = textBox3.Text;
            yeniMusteri.Adres = textBox4.Text;

            bool eklendiMi = Helper.HelperMusteriler.AddMusteri(yeniMusteri);
            if (eklendiMi)
            {
                MessageBox.Show("Müşteri başarı ile eklendi!");
                dataGridView1.Rows.Clear();
                DataGridView1List();
            }
            else
                MessageBox.Show("Müşteri eklenemedi, tekrar deneyiniz.");
        }

        private void button1_Click(object sender, EventArgs e) //müşteri düzenle tablosunu aktifleştirir
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox8.Text = mAd;
                textBox7.Text = mSoyad;
                textBox6.Text = mTel;
                textBox5.Text = mAdres;

                MusterilerModel updm = new MusterilerModel();
                updm.MusteriAd = mAd; 
                updm.MusteriSoyad = mSoyad;
                updm.Telefon = mTel;
                updm.Adres = mAdres;
                musteriID = Helper.HelperMusteriler.FindMusteri(updm);
                button4.Enabled = true;
            }
            else
                MessageBox.Show("Öncelikle listeden düzenlemek istediğiniz müşteriyi seçiniz.");
        }

        private void button4_Click(object sender, EventArgs e) //müşteri düzenle
        {
            MusterilerModel mm = new MusterilerModel();
            mm.MusteriAd = textBox8.Text;
            mm.MusteriSoyad = textBox7.Text;
            mm.Telefon = textBox6.Text;
            mm.Adres = textBox5.Text;
            mm.MusteriID = musteriID;
            Helper.HelperMusteriler.UpdateMusteri(mm);

            dataGridView1.Rows.Clear();
            DataGridView1List();
        }

        private void button6_Click(object sender, EventArgs e) //ürün yönetimi - ürün sil
        {
            DialogResult result = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Ürün Silme", MessageBoxButtons.YesNo);

            if (result==DialogResult.Yes)
            {
                UrunlerModel um = new UrunlerModel();
                um.UrunAd = uAd;
                um.GelisUcret = gUcret;
                um.SatisUcret = sUcret;
                bool silindiMi = Helper.HelperUrunYonetimi.DeleteUrun(Helper.HelperUrunYonetimi.FindUrun(um));
                if (silindiMi)
                {
                    MessageBox.Show("Başarıyla silindi");
                    dataGridView2.Rows.Clear();
                    DataGridView2List(); dataGridView2.ClearSelection();
                }
            }
            else
                MessageBox.Show("Silme işlemi iptal edildi");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            comboBox2.Enabled = true;

            textBox18.Text = uAd;
            comboBox2.SelectedItem = comboBox2.Items[ComboBoxKategori()];
            textBox17.Text = gUcret.ToString();
            textBox16.Text = sUcret.ToString();
            textBox15.Text = stok.ToString();
            textBox14.Text = uAciklama;
        } //düzenle butonu aktifle, verileri aktar

        private void button7_Click(object sender, EventArgs e)
        {
            UrunlerModel um = new UrunlerModel();
            um.UrunAd = textBox9.Text;
            um.KategoriID = Helper.HelperUrunYonetimi.FindKategoriID(comboBox1.SelectedItem.ToString());
            um.GelisUcret = Convert.ToInt32(textBox10.Text);
            um.SatisUcret = Convert.ToInt32(textBox11.Text);
            um.Stok = Convert.ToInt32(textBox12.Text);
            um.UrunDesc = textBox13.Text;

            Helper.HelperUrunYonetimi.AddUrun(um);

            dataGridView2.Rows.Clear(); 
            DataGridView2List(); 
            dataGridView2.ClearSelection();
        }  //ürün ekle

        private void button8_Click(object sender, EventArgs e)
        {
            UrunlerModel dUrun = new UrunlerModel();
            dUrun.UrunAd = textBox18.Text;
            dUrun.KategoriID = Helper.HelperUrunYonetimi.FindKategoriID(comboBox2.SelectedItem.ToString());
            dUrun.GelisUcret = Convert.ToInt32(textBox17.Text);
            dUrun.SatisUcret = Convert.ToInt32(textBox16.Text);
            dUrun.Stok = Convert.ToInt32(textBox15.Text);
            dUrun.UrunID = Helper.HelperUrunYonetimi.FindUrun(dUrun);
            dUrun.UrunDesc = textBox14.Text;

            bool duzenlendiMi = Helper.HelperUrunYonetimi.UpdateUrun(dUrun);
            if (duzenlendiMi)
            {
                MessageBox.Show("Düzenlendi!");
                dataGridView2.Rows.Clear();
                DataGridView2List();
                dataGridView2.ClearSelection();
            }
        } //ürün düzenle

        private void button2_Click(object sender, EventArgs e) //müşteri sil
        {
            DialogResult result = MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Müşteri Silme", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MusterilerModel mm = new MusterilerModel();
                mm.MusteriAd = mAd;
                mm.MusteriSoyad = mSoyad;
                mm.Adres = mAdres;
                mm.Telefon = mTel;
                bool silindiMi = Helper.HelperMusteriler.DeleteMusteri(Helper.HelperMusteriler.FindMusteri(mm));
                if (silindiMi)
                {
                    MessageBox.Show("Silindiler");
                    DataGridView1List();
                }
                else
                    MessageBox.Show("Silme işlemi gerçekleştirilemedi. Daha sonra tekrar deneyiniz.");
            }
            else
                MessageBox.Show("Silme işlemi iptal edildi");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kID = Helper.HelperSatisYonetimi.FindKategoriID(comboBox3.SelectedItem.ToString());
            dataGridView3.Rows.Clear();
            DataGridView3List(kID);
            dataGridView3.ClearSelection();
        } //satış yönetimi combobox'a göre tabloyu doldurur.

        private void button10_Click(object sender, EventArgs e)
        {
            SatislarModel sm = new SatislarModel();
            sm.UrunAdet = Convert.ToInt32(textBox20.Text);
            sm.UrunID = Helper.HelperSatisYonetimi.FindUrunID(textBox19.Text, kID);
            sm.MusteriID = cbMusteri[comboBox4.SelectedIndex];
            sm.SatisDate = DateTime.Now.Date;
            Helper.HelperSatisYonetimi.AddSatislar(sm);

            UrunlerModel um = new UrunlerModel();
            var urunler = Helper.HelperSatisYonetimi.ReturnUrunler();
            foreach (var item in urunler)
            {
                if (item.UrunID == sm.UrunID)
                {
                    um.UrunID = item.UrunID;
                    um.UrunAd = item.UrunAd;
                    um.KategoriID = kID;
                    um.GelisUcret = item.GelisUcret;
                    um.SatisUcret = item.SatisUcret;

                    um.Stok = item.Stok - sm.UrunAdet;
                    um.UrunDesc = item.UrunDesc;
                    Helper.HelperUrunYonetimi.UpdateUrun(um);
                }
            }


        } //satış tamamla

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            if (radioButton1.Checked == true)
            {
                DateTime v1 = dateTimePicker1.Value;
                DateTime v2 = dateTimePicker2.Value;
                var rapor = Helper.HelperSatisYonetimi.MusteriyeGoreRapor(cbMusteri[comboBox5.SelectedIndex], v1, v2);
                label30.Text = Helper.HelperSatisYonetimi.KarZararHesapla().ToString();

                if (rapor.Count() > 0)
                {
                    foreach (var item in rapor)
                    {
                        dataGridView4.Rows.Add(comboBox5.SelectedItem.ToString(), item.km.KategoriAd,
                            item.UrunAd, item.sm.UrunAdet, item.SatisUcret, item.sm.SatisDate);
                    }
                }
                else
                    MessageBox.Show("Girilen aralıklarda bu müşteriye satış gerçekleştirilmemiştir!");
            }

            if (radioButton2.Checked == true)
            {
                DateTime v1 = dateTimePicker1.Value;
                DateTime v2 = dateTimePicker2.Value;
                var rapor = Helper.HelperSatisYonetimi.UruneGoreRapor(cbUrun[comboBox5.SelectedIndex], v1, v2);

                if (rapor.Count() > 0)
                {
                    foreach (var item in rapor)
                    {
                        dataGridView4.Rows.Add(Helper.HelperSatisYonetimi.FindMusteriAd(Convert.ToInt32(item.sm.MusteriID)),
                            item.km.KategoriAd, item.UrunAd, item.sm.UrunAdet, item.SatisUcret, item.sm.SatisDate);
                    }
                }
                else
                    MessageBox.Show("Girilen aralıklarda bu ürün satışı gerçekleştirilmemiştir!");
            }

        }  //rapor filtre


      
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                comboBox5.Items.Clear();
                var musteriList = Helper.HelperMusteriler.MusterilerAsList();
                cbMusteri.Clear();
                foreach (var item in musteriList)
                {
                    comboBox5.Items.Add(item.MusteriAd);
                    cbMusteri.Add(item.MusteriID);
                } 
            }          
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox5.Items.Clear();
                List<UrunlerModel> urunlerList = Helper.HelperUrunYonetimi.UrunlerAsList();
                cbUrun.Clear();
                foreach (var item in urunlerList)
                {
                    comboBox5.Items.Add(item.UrunAd);
                    cbUrun.Add(item.UrunID);
                }

            }
        }

        public void DataGridView1List()
        {
            List<MusterilerModel> musteriList = Helper.HelperMusteriler.MusterilerAsList();
            foreach (MusterilerModel item in musteriList)
            {
                dataGridView1.Rows.Add(item.MusteriAd, item.MusteriSoyad, item.Telefon, item.Adres);
            }
        }  //müşteri listesini gridviewa ekler      
        public void DataGridView2List()
        {
            List<UrunlerModel> urunlerList = Helper.HelperUrunYonetimi.UrunlerAsList();
            foreach (var item in urunlerList)
            {
                dataGridView2.Rows.Add(item.UrunAd, item.km.KategoriAd, item.GelisUcret, item.SatisUcret, item.Stok, item.UrunDesc);
            }

        }  // ürün yönetimi sayfasına ürünleri ekler

        public void DataGridView5List()
        {
            List<KategorilerModel> kategorilerList = Helper.HelperKategoriler.KategorilerAsList();
            foreach (var item in kategorilerList)
            {
                dataGridView5.Rows.Add(item.KategoriAd, item.KategoriDesc);
            }
        }
        public void DataGridView3List(int id)
        {
            var urunlerSatisList = Helper.HelperSatisYonetimi.ReturnUrunler(id);
            foreach (var item in urunlerSatisList)
            {
                dataGridView3.Rows.Add(item.UrunAd, item.SatisUcret, item.UrunDesc);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button13.Enabled = true;
            textBox21.Text = kAd;
            textBox22.Text = kAciklama;
        } //enabled true update kategori buton

        private void button13_Click(object sender, EventArgs e)
        {
            KategorilerModel k = new KategorilerModel();
            k.KategoriAd = textBox20.Text;
            k.KategoriDesc = textBox21.Text;
            k.KategoriID = kID;

            Helper.HelperKategoriler.UpdateKategori(k);
        } //update kategori

        private void button14_Click(object sender, EventArgs e)
        {
            KategorilerModel k = new KategorilerModel();
            k.KategoriAd = textBox24.Text;
            k.KategoriDesc = textBox23.Text;
            Helper.HelperKategoriler.AddKategori(k);

            dataGridView5.Rows.Clear();
            DataGridView5List();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string esifre = textBox25.Text;
            string ysifre = textBox26.Text;
            var k =Helper.GirisDogrulama.SifreDegistir(Form2.kullaniciAdi, esifre, ysifre);
            Helper.GirisDogrulama.UpdateKullanicilar(k);

        }

        public void ComboBox1Fill()
        {
            using (hesapEntities he= new hesapEntities())
            {
                var list = he.Kategoriler.ToList();
                foreach (var item in list)
                {
                    comboBox1.Items.Add(item.KategoriAd);
                }
            }
        } //ürün yönetimi kategori ekleme
        public void ComboBox2Fill()
        {
            using (hesapEntities he = new hesapEntities())
            {
                var list = he.Kategoriler.ToList();
                foreach (var item in list)
                {
                    comboBox2.Items.Add(item.KategoriAd);
                }
            }
        } //ürün yönetimi kategori ekleme
        public int ComboBoxKategori()
        {
            int cid = 0;
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString()==uKategori)
                {
                    cid = i;
                }                  
            }
            return cid;
        }
        public void ComboBox3Fill()
        {
            var list = Helper.HelperUrunYonetimi.KategorilerAsList();
            foreach (var item in list)
            {
                comboBox3.Items.Add(item.km.KategoriAd);
            }
        }
        public void ComboBox4Fill()
        {
            var musteriList = Helper.HelperMusteriler.MusterilerAsList();
            cbMusteri.Clear();
            foreach (var item in musteriList)
            {
                comboBox4.Items.Add(item.MusteriAd);
                cbMusteri.Add(item.MusteriID);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mAd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mSoyad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mTel = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mAdres = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uAd = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            uKategori = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            gUcret = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value);
            sUcret = Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value);
            stok = Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value);
            uAciklama = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox4.Items.Clear();
            ComboBox4Fill();
            UrunlerModel um = new UrunlerModel();
            textBox19.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox19.Enabled = false;
        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kAd = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            kAciklama = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            kID = Helper.HelperKategoriler.FindKategoriID(kAd);

        }


    }
}
