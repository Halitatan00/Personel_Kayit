using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = HALIT\\SQLEXPRESS; Initial Catalog = PersonelVeriTabani; Integrated Security = True; Encrypt=False");
        private void Form2_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komuttps = new SqlCommand("Select Count(*)From Tbl_Personel ", baglanti);
            SqlDataReader dr1 =komuttps.ExecuteReader(); //veri okumak için kullanılır
            while (dr1.Read()) //veriyi okuduğu Sürece
            {
                lbl_tps.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komuteps = new SqlCommand("Select Count(*)From Tbl_Personel Where PerDurum=1", baglanti);
            SqlDataReader dr2=komuteps.ExecuteReader();
            while (dr2.Read())
            {
                lbl_eps.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komutbps = new SqlCommand("Select Count(*)From Tbl_Personel Where PerDurum=0", baglanti);
            SqlDataReader dr3 = komutbps.ExecuteReader();
            while (dr3.Read())
            {
                lbl_bps.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //ŞEHİR SAYISI
            baglanti.Open();
            SqlCommand komutss = new SqlCommand("Select count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komutss.ExecuteReader();
            while (dr4.Read())
            {
                lbl_ss.Text = dr4[0].ToString();
            }
            baglanti.Close();


            //TOPLAM MAAŞ
            baglanti.Open();
            SqlCommand komuttm = new SqlCommand("Select sum(distinct(PerMaas)) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komuttm.ExecuteReader();
            while (dr5.Read())
            {
                lbl_tm.Text = dr5[0].ToString();
            }
            baglanti.Close();


            //ORTALAMA MAAŞ
            baglanti.Open();
            SqlCommand komutom = new SqlCommand("Select avg(distinct(PerMaas)) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komutom.ExecuteReader();
            while (dr6.Read())
            {
                lbl_om.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
