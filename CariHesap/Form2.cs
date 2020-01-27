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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static string kullaniciAdi;
        private void button1_Click(object sender, EventArgs e)
        {
            
            bool devamMi = true;
            while (devamMi)
            {
                kullaniciAdi = textBox1.Text;
                string sifre = textBox2.Text;
                int donus = Helper.GirisDogrulama.Giris(kullaniciAdi, sifre);
                if (donus==0)
                {
                    devamMi = false;
                    Form1 f = new Form1();                   
                    f.Show();
                    this.Hide();
                }         
            }
            
        }
    }
}
