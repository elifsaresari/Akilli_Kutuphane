using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace yoneticigiris
{
    public partial class kayitol : Form
    {
        public kayitol()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6O4GPNU\\SQLEXPRESS;Initial Catalog=akıllı_kutuphane;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            giris g = new giris();
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty  /*deneme()*/ ) 
            { 
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into KULLANICILAR(TC,AD,SOYAD,EMAİL,KULLANICI_ADI,ŞİFRE)  values ('"+textBox1.Text.ToString() +"','" 
                + textBox2.Text.ToString() + "','"
                + textBox3.Text.ToString() + "','"
                + textBox4.Text.ToString() + "','"
                + textBox5.Text.ToString() + "','"
                + textBox6.Text.ToString() + "')", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            }
            else if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty||textBox5.Text==string.Empty || textBox6.Text == string.Empty 
              )
            {
                MessageBox.Show("Boş alanları doldurunuz!", "HATA!");
            }

            baglan.Close();
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void kayitol_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            textBox3.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            textBox4.ForeColor = Color.WhiteSmoke;
            panel4.BackColor = Color.WhiteSmoke;
            textBox5.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            textBox6.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.gerimove;
            button3.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources._3401;
        }

        private void ykayitTcTextBox_MouseClick(object sender, MouseEventArgs e)
        {

            textBox1.ForeColor = Color.FromArgb(78, 184, 206);
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            textBox2.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            textBox3.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            textBox4.ForeColor = Color.WhiteSmoke;
            panel4.BackColor = Color.WhiteSmoke;
            textBox5.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            textBox6.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
        }

        private void ykayitAdTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("TC alanı boş bırakılamaz.");
                textBox1.Focus();
                textBox1.ForeColor = Color.FromArgb(78, 184, 206);
                panel1.BackColor = Color.FromArgb(78, 184, 206);
                return;
            }

            textBox2.ForeColor = Color.FromArgb(78, 184, 206);
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            textBox4.ForeColor = Color.WhiteSmoke;
            panel4.BackColor = Color.WhiteSmoke;
            textBox3.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            textBox6.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            textBox5.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
        }

        private void ykayitAdTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                textBox2.Cursor = Cursors.No;
            }

            else
            {
                textBox2.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitSoyadTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("AD alanı boş bırakılamaz.");
                textBox2.Focus();
                textBox2.ForeColor = Color.FromArgb(78, 184, 206);
                panel2.BackColor = Color.FromArgb(78, 184, 206);
                return;
            }
            textBox3.ForeColor = Color.FromArgb(78, 184, 206);
            panel3.BackColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            textBox4.ForeColor = Color.WhiteSmoke;
            panel4.BackColor = Color.WhiteSmoke;
            textBox6.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            textBox5.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
        }

        private void ykayitSoyadTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {
                textBox3.Cursor = Cursors.No;
            }

            else
            {
                textBox3.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitEmailTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("SOYAD alanı boş bırakılamaz.");
                textBox3.Focus();
                textBox3.ForeColor = Color.FromArgb(78, 184, 206);
                panel3.BackColor = Color.FromArgb(78, 184, 206);
                textBox1.ForeColor = Color.WhiteSmoke;
                panel1.BackColor = Color.WhiteSmoke;
                textBox2.ForeColor = Color.WhiteSmoke;
                panel2.BackColor = Color.WhiteSmoke;
                textBox4.ForeColor = Color.WhiteSmoke;
                panel4.BackColor = Color.WhiteSmoke;
                textBox6.ForeColor = Color.WhiteSmoke;
                panel6.BackColor = Color.WhiteSmoke;
                textBox5.ForeColor = Color.WhiteSmoke;
                panel5.BackColor = Color.WhiteSmoke;
                return;
            }
            textBox4.ForeColor = Color.FromArgb(78, 184, 206);
            panel4.BackColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            textBox3.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            textBox5.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            textBox6.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
        }

        private void ykayitEmailTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == String.Empty)
            {
                textBox4.Cursor = Cursors.No;
            }

            else
            {
                textBox4.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitKullanıcıadiTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("E-MAİL alanı boş bırakılamaz.");
                textBox4.Focus();
                textBox4.ForeColor = Color.FromArgb(78, 184, 206);
                panel4.BackColor = Color.FromArgb(78, 184, 206);
                textBox1.ForeColor = Color.WhiteSmoke;
                panel1.BackColor = Color.WhiteSmoke;
                textBox2.ForeColor = Color.WhiteSmoke;
                panel2.BackColor = Color.WhiteSmoke;
                textBox3.ForeColor = Color.WhiteSmoke;
                panel3.BackColor = Color.WhiteSmoke;
                textBox6.ForeColor = Color.WhiteSmoke;
                panel6.BackColor = Color.WhiteSmoke;
                textBox5.ForeColor = Color.WhiteSmoke;
                panel5.BackColor = Color.WhiteSmoke;
                return;
            }
            textBox5.ForeColor = Color.FromArgb(78, 184, 206);
            panel5.BackColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            textBox3.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            textBox4.ForeColor = Color.WhiteSmoke;
            panel4.BackColor = Color.WhiteSmoke;
            textBox6.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
        }

        private void ykayitKullanıcıadiTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == String.Empty)
            {
                textBox5.Cursor = Cursors.No;
            }

            else
            {
                textBox5.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitSifreTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("KULLANICI ADI alanı boş bırakılamaz.");
                textBox5.Focus();
                textBox5.ForeColor = Color.FromArgb(78, 184, 206);
                panel5.BackColor = Color.FromArgb(78, 184, 206);
                textBox6.ForeColor = Color.FromArgb(78, 184, 206);
                panel6.BackColor = Color.FromArgb(78, 184, 206);
                textBox1.ForeColor = Color.WhiteSmoke;
                panel1.BackColor = Color.WhiteSmoke;
                textBox2.ForeColor = Color.WhiteSmoke;
                panel2.BackColor = Color.WhiteSmoke;
                textBox3.ForeColor = Color.WhiteSmoke;
                panel3.BackColor = Color.WhiteSmoke;
                textBox4.ForeColor = Color.WhiteSmoke;
                panel4.BackColor = Color.WhiteSmoke;
                textBox6.ForeColor = Color.WhiteSmoke;
                panel6.BackColor = Color.WhiteSmoke;
                return;
            }
            textBox6.ForeColor = Color.FromArgb(78, 184, 206);
            panel6.BackColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
            panel2.BackColor = Color.WhiteSmoke;
            textBox3.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            textBox4.ForeColor = Color.WhiteSmoke;
            panel4.BackColor = Color.WhiteSmoke;
            textBox5.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
        }

        private void ykayitSifreTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == String.Empty)
            {
                textBox6.Cursor = Cursors.No;
            }

            else
            {
                textBox6.Cursor = Cursors.IBeam;
            }
        }
    }
}
