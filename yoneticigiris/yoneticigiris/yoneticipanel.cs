using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace yoneticigiris
{
    public partial class yoneticipanel : Form
    {
        public yoneticipanel()
        {
            InitializeComponent();
        }

        private void yoneticipanel_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void cikis_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void geri_button_Click(object sender, EventArgs e)
        {
            yoneticiGiris yg = new yoneticiGiris();
            this.Close();
            yg.Show();           
        }

        private void cikis_button_MouseMove(object sender, MouseEventArgs e)
        {
            cikis_button.BackgroundImage = Properties.Resources.exitleave;
            cikis_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void geri_button_MouseMove(object sender, MouseEventArgs e)
        {
            geri_button.BackgroundImage = Properties.Resources.gerimove;
            geri_button.BackColor = Color.FromArgb(34, 36, 49);
        }
        private void kitapislemleri_button_MouseMove(object sender, MouseEventArgs e)
        {
          kitapislemleri_button.BackgroundImage = Properties.Resources.bookmavi;
            label2.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void uyeislemleri_button_MouseMove(object sender, MouseEventArgs e)
        {
            uyeislemleri_button.BackgroundImage = Properties.Resources.User_icon_BLACK_01;
            label3.ForeColor = Color.FromArgb(78, 184, 206);

        }
        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            uyeislemleri_button.BackgroundImage = Properties.Resources.User_icon_BLACK_01;
            label3.ForeColor = Color.FromArgb(78, 184, 206);
        }


        private void kitapislemleri_button_Click(object sender, EventArgs e)
        {
            kitapislemleri ki = new kitapislemleri();
            ki.Show();
            this.Close();
        }

        private void uyeislemleri_button_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            uyeislemleri ui = new uyeislemleri();
            ui.Show();
            
        }

        private void emanetislemleri_button_MouseMove(object sender, MouseEventArgs e)
        {
            emanetislemleri_button.BackgroundImage = Properties.Resources.takvimmavi;
            label4.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            emanetislemleri_button.BackgroundImage = Properties.Resources.takvimmavi;
            label4.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void emanetislemleri_button_MouseLeave(object sender, EventArgs e)
        {
            emanetislemleri_button.BackgroundImage = Properties.Resources.takvimbeyaz;
            label4.ForeColor = Color.WhiteSmoke;
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            emanetislemleri_button.BackgroundImage = Properties.Resources.takvimbeyaz;
            label1.ForeColor = Color.WhiteSmoke;
        }

        private void uyeislemleri_button_MouseLeave(object sender, EventArgs e)
        {

            uyeislemleri_button.BackgroundImage = Properties.Resources.User_icon_BLACK_011;
            label3.ForeColor = Color.WhiteSmoke;

        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            uyeislemleri_button.BackgroundImage = Properties.Resources.User_icon_BLACK_011;
            label3.ForeColor = Color.WhiteSmoke;
        }

        private void geri_button_MouseLeave(object sender, EventArgs e)
        {
            geri_button.BackgroundImage = Properties.Resources._3401;
            geri_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void cikis_button_MouseLeave(object sender, EventArgs e)
        {
            cikis_button.BackgroundImage = Properties.Resources.exit1;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            kitapislemleri_button.BackgroundImage = Properties.Resources.bookmavi;
            label2.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void kitapislemleri_button_MouseLeave(object sender, EventArgs e)
        {
            kitapislemleri_button.BackgroundImage = Properties.Resources.bookbeyaz;
            label2.ForeColor = Color.WhiteSmoke;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            kitapislemleri_button.BackgroundImage = Properties.Resources.bookbeyaz;
            label2.ForeColor = Color.WhiteSmoke;
        }

       /* private void geri_button_Click_1(object sender, EventArgs e)
        {
            yoneticiGiris yo = new yoneticiGiris();
            yo.Show();
            this.Close();
        }*/
        private void emanetislemleri_button_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
