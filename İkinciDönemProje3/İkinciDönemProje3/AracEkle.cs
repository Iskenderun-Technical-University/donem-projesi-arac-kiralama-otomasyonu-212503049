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
    public partial class AracEkle : Form
    {
        public AracEkle()
        {
            InitializeComponent();
        }
        private string sqlbaglanti = @"Data Source=EMIR\SQLEXPRESS;Initial Catalog=İkinciDonemProje;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlbaglanti);
            baglanti.Open();

            string komutCumlesi = "Insert Into Araclar Values (@plaka,@Marka,@Seri,@Model,@Km,@Yakit,@Yakittipi,@Ücret,@Durumu)";
            SqlCommand komut = new SqlCommand(komutCumlesi, baglanti);
            komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut.Parameters.AddWithValue("@Marka", cmbMarka.SelectedItem);
            komut.Parameters.AddWithValue("@Seri", cmbSeri.SelectedItem);
            komut.Parameters.AddWithValue("@Model", txtModel.Text);
            komut.Parameters.AddWithValue("@Km", txtKm.Text);
            komut.Parameters.AddWithValue("@Yakit", txtMiktar.Text);
            komut.Parameters.AddWithValue("@Yakittipi", cmbYakıt.SelectedItem);
            komut.Parameters.AddWithValue("@Ücret", txtÜcret.Text);
            komut.Parameters.AddWithValue("@Durumu", cmbDurum.SelectedItem);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı");
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSeri.Items.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfafrm = new AnaSayfa();
            anasayfafrm.Show();
            this.Hide();
        }
    }
    
}
