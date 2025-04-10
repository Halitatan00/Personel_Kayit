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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Sql ile Arasında baglantı kurma kısmı
        SqlConnection baglanti =new SqlConnection("Data Source = HALIT\\SQLEXPRESS; Initial Catalog = PersonelVeriTabani; Integrated Security = True; Encrypt=False");
        string Durum;
        void temizle()
        {
            tx_ad.Text = "";
            tx_id.Text = "";
            tx_maas.Text = "";
            tx_meslek.Text = "";
            tx_soyad.Text = "";
            rd_bekar.Checked = false;
            rb_evli.Checked = false;
            cb_sehir.Text = "";
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut =new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti); //komut kullanma
            //command ile sorgular yapılır sonucu alınır
            komut.Parameters.AddWithValue("@p1", tx_ad.Text); //seçtiğin parametliye eklemek için
            komut.Parameters.AddWithValue("@p2", tx_soyad.Text);
            komut.Parameters.AddWithValue("@p3", cb_sehir.Text); 
            komut.Parameters.AddWithValue("@p4", tx_maas.Text);
            komut.Parameters.AddWithValue("@p5", tx_meslek.Text);
            komut.Parameters.AddWithValue("@p6", Durum);
            komut.ExecuteNonQuery(); //Tabloda ekleme silme vb şey ler varsa komutu çalıştırır
            baglanti.Close();   
            MessageBox.Show("Personel Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void rb_evli_CheckedChanged(object sender, EventArgs e)
        {
            Durum = "True";
        }

        private void rd_bekar_CheckedChanged(object sender, EventArgs e)
        {
            Durum = "False";
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilendeger=dataGridView1.SelectedCells[0].RowIndex; // Seçilen değerin datasını aldı
            tx_id.Text=dataGridView1.Rows[secilendeger].Cells[0].Value.ToString();//Text id ye secilen id yi yollama
            tx_ad.Text = dataGridView1.Rows[secilendeger].Cells[1].Value.ToString();
            tx_soyad.Text = dataGridView1.Rows[secilendeger].Cells[2].Value.ToString();
            cb_sehir.Text = dataGridView1.Rows[secilendeger].Cells[3].Value.ToString();
            tx_maas.Text = dataGridView1.Rows[secilendeger].Cells[4].Value.ToString();
            Durum = dataGridView1.Rows[secilendeger].Cells[5].Value.ToString(); //Radio buttondan alma
            if (Durum == "True")
            {
                rb_evli.Checked = true;
            }
            else { 
                rd_bekar.Checked = true;
            }
            tx_meslek.Text = dataGridView1.Rows[secilendeger].Cells[6].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil =new SqlCommand("Delete From Tbl_Personel Where Perid=@s1",baglanti);
            komutsil.Parameters.AddWithValue("@s1",tx_id.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            baglanti.Close();
            temizle();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("UPDATE Tbl_Personel Set PerAd=@g1,PerSoyad=@g2,PerSehir=@g3,PerMaas=@g4,PerDurum=@g5,PerMeslek=@g6 Where Perid=@g7",baglanti);
            komutguncelle.Parameters.AddWithValue("@g1", tx_ad.Text);
            komutguncelle.Parameters.AddWithValue("@g2", tx_soyad.Text);
            komutguncelle.Parameters.AddWithValue("@g3", cb_sehir.Text);
            komutguncelle.Parameters.AddWithValue("@g4", tx_maas.Text);
            komutguncelle.Parameters.AddWithValue("@g5", Durum);
            komutguncelle.Parameters.AddWithValue("@g6", tx_meslek.Text);
            komutguncelle.Parameters.AddWithValue("@g7", tx_id.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void btn_istatistik_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void btn_grafik_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fr3 = new Form3();
            fr3.Show();
        }

        private void btn_rapor_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fr4 = new Form4();
            fr4.Show();   
        }
    }
}
