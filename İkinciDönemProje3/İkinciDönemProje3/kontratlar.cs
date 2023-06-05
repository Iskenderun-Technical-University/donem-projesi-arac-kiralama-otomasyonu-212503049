using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace İkinciDönemProje3
{
    public partial class kontratlar : Form
    {
        public kontratlar()
        {
            InitializeComponent();
        }
        private string sqlbaglanti = @"Data Source=EMIR\SQLEXPRESS;Initial Catalog=İkinciDonemProje;Integrated Security=True";

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();
            string komutCumlesi = "Select * From Musteriler where TCNo like '" + txtTcAra.Text + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtTCNo.Text = read["TCNo"].ToString();
                txtAd.Text = read["Ad"].ToString();
                txtSoyad.Text = read["Soyad"].ToString();
                maskedTextBox1.Text = read["TelNo"].ToString();
                txtEposta.Text = read["Mail"].ToString();
                txtAdres.Text = read["Adres"].ToString();

            }
        }
        public void Arac_Listele()
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();
            string komutCumlesi = "Select * From Araclar where Durumu = 'Musait'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmbplaka.Items.Add(read["Plaka"]);
            }
        }

        private void kontratlar_Load(object sender, EventArgs e)
        {
            Arac_Listele();
            Sozlesme_Listele();
        }
        public void Sozlesme_Listele()
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            String komutCumlesi = "Select * From Sozlesme";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void cmbplaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();
            string komutCumlesi = "Select * From Araclar where Plaka like '" + cmbplaka.SelectedItem + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtMarka.Text = read["Marka"].ToString();
                txtSeri.Text = read["Seri"].ToString();
                txtModel.Text = read["Model"].ToString();
                txtKm.Text = read["Kilometre"].ToString();
                txtMiktar.Text = read["Yakıt"].ToString();
                txtYakittipi.Text = read["YakıtTipi"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan gunfarki = DateTime.Parse(dateTimeDonus.Text) - DateTime.Parse(dateTimeCikis.Text);
            int gunhesap = gunfarki.Days;
            txtGün.Text = gunhesap.ToString();

            txtUcret.Text = (gunhesap * int.Parse(txtKiraÜcreti.Text)).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = "Insert Into Sozlesme Values (@tcno,@Ad,@Soyad,@Telefon,@Eposta,@Adres,@ehliyetno,@plaka,@Marka,@Seri,@Model,@Kilometre,@Yakitmiktari,@Yakittipi,@kirasekli,@kiraücreti,@kiralanangünsayisi,@tutar,@cikistarih,@dönüstarih)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@tcno", txtTCNo.Text);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Eposta", txtEposta.Text);
            komut.Parameters.AddWithValue("@Adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@ehliyetno", txtEhliyet.Text);
            komut.Parameters.AddWithValue("@plaka", cmbplaka.SelectedItem);
            komut.Parameters.AddWithValue("@Marka", txtMarka.Text);
            komut.Parameters.AddWithValue("@Seri", txtSeri.Text);
            komut.Parameters.AddWithValue("@Model", txtModel.Text);
            komut.Parameters.AddWithValue("@Kilometre", txtKm.Text);
            komut.Parameters.AddWithValue("@Yakitmiktari", txtMiktar.Text);
            komut.Parameters.AddWithValue("@Yakittipi", txtYakittipi.Text);
            komut.Parameters.AddWithValue("@kirasekli", cmbKiraSekli.SelectedItem);
            komut.Parameters.AddWithValue("@kiraücreti", txtKiraÜcreti.Text);
            komut.Parameters.AddWithValue("@kiralanangünsayisi", txtGün.Text);
            komut.Parameters.AddWithValue("@tutar", txtUcret.Text);
            komut.Parameters.AddWithValue("@cikistarih", dateTimeCikis.Value);
            komut.Parameters.AddWithValue("@dönüstarih", dateTimeDonus.Value);

            string komutCumlesiUp = "update Araclar set Durumu = 'MusaitDegil' where Plaka ='" + cmbplaka.SelectedItem + "'";
            SqlCommand komutUp = new SqlCommand(komutCumlesiUp, baglanti);

            komutUp.ExecuteNonQuery();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Sozlesme_Listele();
            Arac_Listele();
            MessageBox.Show("Kayıt Başarılı");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AnaSayfa anasayfafrm = new AnaSayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
