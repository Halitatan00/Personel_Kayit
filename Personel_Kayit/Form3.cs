﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = HALIT\\SQLEXPRESS; Initial Catalog = PersonelVeriTabani; Integrated Security = True; Encrypt=False");
        private void chart1_Click(object sender, EventArgs e)
        {   
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            //Grafik 1
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select PerSehir,COUNT(*) From Tbl_Personel Group By PerSehir", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //Grafik 2
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select PerMeslek,AVG(PerMaas) From Tbl_Personel Group By PerMeslek", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();

        }
    }
}
