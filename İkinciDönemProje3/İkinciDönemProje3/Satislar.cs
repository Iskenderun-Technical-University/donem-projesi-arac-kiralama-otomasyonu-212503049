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
    public partial class Satislar : Form
    {
        public Satislar()
        {
            InitializeComponent();
        }
        private string sqlbaglanti = @"Data Source=EMIR\SQLEXPRESS;Initial Catalog=İkinciDonemProje;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
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
    }
}
