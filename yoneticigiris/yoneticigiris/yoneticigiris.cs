using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace yoneticigiris
{
    public partial class yoneticiGiris : Form
    {
        public yoneticiGiris()
        {
            InitializeComponent();
        }
        
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6O4GPNU\\SQLEXPRESS;Initial Catalog=akıllı_kutuphane;Integrated Security=True");
        private void girisyap()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from KULLANICILAR", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            uyarı uy = new uyarı();
            while (oku.Read())
            {
                if (kullaniciadiTextBox.Text == oku["KULLANICI_ADI"].ToString() && sifreTextBox.Text == oku["ŞİFRE"].ToString() && oku["ROL_ID"].ToString() == "1")
                {
                    this.Close();                   
                    yoneticipanel yp = new yoneticipanel();
                    uy.l.Text = "Giriş Başarılı!";
                    uy.basariliyonetici();
                    this.Close();
                    baglan.Close();
                    return;
                }
            }
   
            uy.hata("Hatalı giriş yaptınız!");
            this.Close();
            yoneticiGiris yg = new yoneticiGiris();
            yg.Show();
            baglan.Close();
        }
        private void yoneticiGiris_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.User_icon_BLACK_011;
            panel1.BackColor = Color.WhiteSmoke;
            kullaniciadiTextBox.ForeColor = Color.WhiteSmoke;

            pictureBox2.BackgroundImage = Properties.Resources.password_21;
            panel2.BackColor = Color.WhiteSmoke;
            sifreTextBox.ForeColor = Color.WhiteSmoke;
        }

        private void kullaniciadiTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.user_move;
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            kullaniciadiTextBox.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox2.BackgroundImage = Properties.Resources.password_21;
            panel2.BackColor = Color.WhiteSmoke;
            sifreTextBox.ForeColor = Color.WhiteSmoke;
        }

        private void sifreTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.password_move;
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            sifreTextBox.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox1.BackgroundImage = Properties.Resources.User_icon_BLACK_011;
            panel1.BackColor = Color.WhiteSmoke;
            kullaniciadiTextBox.ForeColor = Color.WhiteSmoke;
            if (kullaniciadiTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("Kullanıcı Adı alanı boş bırakılamaz.");
                kullaniciadiTextBox.Focus();
                pictureBox1.BackgroundImage = Properties.Resources.user_move;
                panel2.BackColor = Color.FromArgb(78, 184, 206);
                kullaniciadiTextBox.ForeColor = Color.FromArgb(78, 184, 206);

                pictureBox2.BackgroundImage = Properties.Resources.password_21;
                panel2.BackColor = Color.WhiteSmoke;
                sifreTextBox.ForeColor = Color.WhiteSmoke;
                return;

            }
        }

        private void sifreTextBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (kullaniciadiTextBox.Text == String.Empty)
            {
                sifreTextBox.Cursor = Cursors.No;
            }

            else
            {
                sifreTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void giris_button_Click(object sender, EventArgs e)
        {
            if (sifreTextBox.Text == String.Empty)
            {
                this.Close();
                uyarı uy = new uyarı();
                uy.hata("Alanlardan birini boş bıraktınız!");
                return;
            }
            girisyap();
            //this.Close();
        }

        private void giris_button_MouseMove(object sender, MouseEventArgs e)
        {
            giris_button.BackColor = Color.WhiteSmoke;
        }

        private void giris_button_MouseLeave(object sender, EventArgs e)
        {
            giris_button.BackColor = Color.FromArgb(78, 184, 206);

        }

        private void cikis_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geri_button_Click(object sender, EventArgs e)
        {
            this.Close();
            giris g = new giris();
            g.Show();
        }
 
        private void linkLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            linkLabel1.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.ForeColor = Color.WhiteSmoke;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void cikis_button_MouseMove(object sender, MouseEventArgs e)
        {
            cikis_button.BackgroundImage = Properties.Resources.exitleave;
            cikis_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void cikis_button_MouseLeave(object sender, EventArgs e)
        {
            cikis_button.BackgroundImage = Properties.Resources.exit1;
        }

        private void geri_button_MouseMove(object sender, MouseEventArgs e)
        {
            geri_button.BackgroundImage = Properties.Resources.gerimove;
            geri_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void geri_button_MouseLeave(object sender, EventArgs e)
        {
            geri_button.BackgroundImage = Properties.Resources._3401;
        }
    }
}
