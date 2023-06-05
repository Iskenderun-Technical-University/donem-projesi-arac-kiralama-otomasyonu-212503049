using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İkinciDönemProje3
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriEkle musterieklefrm=new MusteriEkle();
            musterieklefrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusteriListele musterilistelefrm=new MusteriListele();
            musterilistelefrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AracEkle araceklefrm=new AracEkle();
            araceklefrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AracListele araclistelefrm = new AracListele();
            araclistelefrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kontratlar sözlesmefrm = new kontratlar();
            sözlesmefrm.Show();
                
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Satislar satislarfrm = new Satislar();
            satislarfrm.Show();
        }
    }
    
}
