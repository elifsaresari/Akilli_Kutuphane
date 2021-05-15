using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace yoneticigiris
{
    public partial class emanet : Form
    {
        public emanet()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            giris g = new giris();
            g.Show();
        }
    }
}
