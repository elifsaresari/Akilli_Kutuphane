using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace yoneticigiris
{
    public partial class uyarı : Form
    {
        public uyarı()
        {
            InitializeComponent();
            this.Visible = false;
        }

       public Label l= new Label();
        

        public void hata(string cümle)
        {
            pictureBox1.Size = new Size(120, 90);
            pictureBox1.BackgroundImage = Properties.Resources.uyarı_beyaz;
            label1.Text = cümle;
            this.ShowDialog();
        }
        public bool basariliyonetici()
        {
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.BackgroundImage = Properties.Resources.başarıbeyaz;
            label1.Text = l.Text;
            /*yoneticiGiris yo = new yoneticiGiris();
            yo.Close();*/
            yoneticipanel yp = new yoneticipanel();
            yp.Show();
            this.ShowDialog();
            return true;
        }
        public bool basariliuye()
        {
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.BackgroundImage = Properties.Resources.başarıbeyaz;
            label1.Text = l.Text;
            uyegiris ug = new uyegiris();
            ug.Close();
            uyepanel uy = new uyepanel();
            uy.Show();
            this.ShowDialog();
            return false;
        }

        public bool basarili()
        {
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.BackgroundImage = Properties.Resources.başarıbeyaz;
            label1.Text = l.Text;
            /*uyegiris ug = new uyegiris();
            ug.Close();
            /*uyepanel uy = new uyepanel();
            uy.Show();*/
            this.ShowDialog();
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        { 
            this.Close();      
        }
    }
}
