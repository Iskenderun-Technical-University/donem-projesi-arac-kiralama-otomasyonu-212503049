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
    public partial class MusteriListele : Form
    {
        public MusteriListele()
        {
            InitializeComponent();
        }
        private string sqlbaglanti = @"Data Source=EMIR\SQLEXPRESS;Initial Catalog=İkinciDonemProje;Integrated Security=True";

        public void Musteri_Listele()
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            String komutCumlesi = "Select TcNo,Ad,Soyad,TelNo,Mail,Adres,Musteri_id from Musteriler";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        public void Musteri_Sil()
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = "Delete from Musteriler where TCNo='" + dataGridView1.CurrentRow.Cells["TCNo"].Value.ToString() + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
            Musteri_Listele();
        }
        public void MusteriListele_Load(object sender, EventArgs e)
        {
            Musteri_Listele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTCNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox1.Text=dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEposta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = "Update Musteriler set Ad=@ad,Soyad=@soyad,TelNo=@telefon,Mail=@mail,Adres=@adres,TCNo=@tc where Musteri_id=@id";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tc", txtTCNo.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@mail", txtEposta.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@id",dataGridView1.CurrentRow.Cells[6].Value);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı");
            Musteri_Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteri_Sil();
        }

        private void txtTCNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfafrm = new AnaSayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
