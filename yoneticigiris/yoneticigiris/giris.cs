using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace yoneticigiris
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
            private void cikis_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ygiris_button_Click(object sender, EventArgs e)
        {
            yoneticiGiris yo = new yoneticiGiris();
            yo.Show();
            this.Hide();
        }

        private void ugiris_button_Click(object sender, EventArgs e)
        {
            uyegiris uy = new uyegiris();
            uy.Show();
            this.Hide();
        }

        private void kayitol_button_Click(object sender, EventArgs e)
        {
            kayitol ko = new kayitol();
            ko.Show();
            this.Hide();
        }

        private void ygiris_button_MouseMove(object sender, MouseEventArgs e)
        {
            ygiris_button.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void ygiris_button_MouseLeave(object sender, EventArgs e)
        {
            ygiris_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void ugiris_button_MouseLeave(object sender, EventArgs e)
        {
            ugiris_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void ugiris_button_MouseMove(object sender, MouseEventArgs e)
        {
            ugiris_button.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void kayitol_button_MouseMove(object sender, MouseEventArgs e)
        {
            kayitol_button.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void kayitol_button_MouseLeave(object sender, EventArgs e)
        {
            kayitol_button.BackColor = Color.FromArgb(34, 36, 49);
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
    }
}
