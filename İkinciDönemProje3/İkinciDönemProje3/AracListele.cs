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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace İkinciDönemProje3
{
    public partial class AracListele : Form
    {
        public AracListele()
        {
            InitializeComponent();
        }
        private string sqlbaglanti = @"Data Source=EMIR\SQLEXPRESS;Initial Catalog=İkinciDonemProje;Integrated Security=True";

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbMarka.SelectedIndex == 0)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Corolla");
                cmbSeri.Items.Add("Camry");
                cmbSeri.Items.Add("RAV4");
                cmbSeri.Items.Add("Hilux");
                cmbSeri.Items.Add("Prius");

            }
            else if (cmbMarka.SelectedIndex == 1)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Mustang");
                cmbSeri.Items.Add("Focus");
                cmbSeri.Items.Add("Fiesta");
                cmbSeri.Items.Add("Explorer");
                cmbSeri.Items.Add("F-150");
            }
            else if (cmbMarka.SelectedIndex == 2)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("M 520");
                cmbSeri.Items.Add("M4 competition");
                cmbSeri.Items.Add("M 63");
                cmbSeri.Items.Add("X5");
                cmbSeri.Items.Add("M4");
            }
            else if (cmbMarka.SelectedIndex == 3)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Golf");
                cmbSeri.Items.Add("Passat");
                cmbSeri.Items.Add("Polo");
                cmbSeri.Items.Add("Tiguan");
                cmbSeri.Items.Add("JettaJetta");
            }
            else if (cmbMarka.SelectedIndex == 4)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Civic");
                cmbSeri.Items.Add("Accord");
                cmbSeri.Items.Add("CR-V");
                cmbSeri.Items.Add("HR-V");
                cmbSeri.Items.Add("Odyssey");
            }
            else if (cmbMarka.SelectedIndex == 5)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("C 200");
                cmbSeri.Items.Add("E 200d");
                cmbSeri.Items.Add("GLC 250");
                cmbSeri.Items.Add("S-Klasse");
                cmbSeri.Items.Add("GLE 300");
            }
            else if (cmbMarka.SelectedIndex == 6)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("A4");
                cmbSeri.Items.Add("A6");
                cmbSeri.Items.Add("Q5");
                cmbSeri.Items.Add("Q8");
                cmbSeri.Items.Add("R8");
            }
            else if (cmbMarka.SelectedIndex == 7)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Altima");
                cmbSeri.Items.Add("Maxima");
                cmbSeri.Items.Add("Rogue");
                cmbSeri.Items.Add("Pathfinder");
                cmbSeri.Items.Add("GT-R");
            }
            else if (cmbMarka.SelectedIndex == 8)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Camaro");
                cmbSeri.Items.Add("Silverado");
                cmbSeri.Items.Add("Equinox");
                cmbSeri.Items.Add("Traverse");
                cmbSeri.Items.Add("Malibu");
            }
            else if (cmbMarka.SelectedIndex == 9)
            {
                cmbSeri.Items.Clear();
                cmbSeri.Text = "";
                cmbSeri.Items.Add("Elantra");
                cmbSeri.Items.Add("Sonata");
                cmbSeri.Items.Add("Tucson");
                cmbSeri.Items.Add("Santa Fe");
                cmbSeri.Items.Add("Kona");
            }
        }
        public void Arac_Listele()
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            String komutCumlesi = "Select Plaka,Marka,Seri,Model,Kilometre,Yakıt,YakıtTipi,KiraUcret,Durumu,id from Araclar";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void AracListele_Load(object sender, EventArgs e)
        {
            Arac_Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPlaka.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmbMarka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbSeri.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtModel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtKm.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMiktar.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbYakıt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtÜcret.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cmbDurum.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = ("Update Araclar set Plaka=@plaka,Marka=@marka,Seri=@seri,Model=@model,Kilometre=@km,Yakıt=@yakit,YakıtTipi=@yakittipi,KiraUcret=@kira,Durumu=@durum where id=@id");
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut.Parameters.AddWithValue("@marka", cmbMarka.SelectedItem);
            komut.Parameters.AddWithValue("@seri", cmbSeri.SelectedItem);
            komut.Parameters.AddWithValue("@model", txtModel.Text);
            komut.Parameters.AddWithValue("@km", txtKm.Text);
            komut.Parameters.AddWithValue("@yakit", txtMiktar.Text);
            komut.Parameters.AddWithValue("@yakittipi", cmbYakıt.SelectedItem);
            komut.Parameters.AddWithValue("@kira", txtÜcret.Text);
            komut.Parameters.AddWithValue("@durum", cmbDurum.SelectedItem);
            komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[9].Value);



            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı");
            Arac_Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = "Delete from Araclar where Plaka='" + dataGridView1.CurrentRow.Cells["Plaka"].Value.ToString() + "'";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
            Arac_Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfafrm = new AnaSayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
}
