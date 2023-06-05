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

namespace İkinciDönemProje3
{
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }
        private string sqlbaglanti = @"Data Source=EMIR\SQLEXPRESS;Initial Catalog=İkinciDonemProje;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfafrm =new AnaSayfa();
            anasayfafrm.Show();
            this.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = "Insert Into Musteriler Values (@tcno,@Ad,@Soyad,@Telefon,@Mail,@Adres)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tcno", txtTCNo.Text);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Telefon",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Mail", txtEposta.Text);
            komut.Parameters.AddWithValue("@Adres", txtAdres.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı");
        }
    }
}
