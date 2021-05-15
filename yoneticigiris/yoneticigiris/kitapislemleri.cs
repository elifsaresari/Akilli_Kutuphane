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
    public partial class kitapislemleri : Form
    {
        public kitapislemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6O4GPNU\\SQLEXPRESS;Initial Catalog=akıllı_kutuphane;Integrated Security=True");

        void getir()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from KITAPLAR", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            int sira;
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                sira = kitapIslem_List.Items.Count;
                if (aramaTextBox.Text == tablo.Rows[i]["KITAP_ID"].ToString())
                {
                    kitapIslem_List.Items.Add(tablo.Rows[i]["KITAP_ID"].ToString());
                    kitapIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["KITAP_ADI"].ToString());
                    kitapIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["YAZAR"].ToString());
                    kitapIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["YAYINEVİ"].ToString());
                    kitapIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["SAYFA"].ToString());
                }
            }
            baglan.Close();
        }

        private bool deneme()
        {
            bool x = false; ;
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from KITAPLAR", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                if ( ykayitKitapnoBox==tablo.Rows[i]["KITAP_ID"])
                {
                    uyarı uy = new uyarı();
                    uy.hata("Bu kitap kayıtlı.");
                   // MessageBox.Show("Bu kitap kayıtlı.");
                    x = false;
                    break;
                }

                else
                {
                    x = true;
                }
            }
            baglan.Close();
            return x;
        }
        private void kitap_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            yoneticipanel yp = new yoneticipanel();
            yp.Show();
        }

        private void arama_button_Click(object sender, EventArgs e)
        {
            kitapIslem_List.Items.Clear();
            getir();
            aramaTextBox.ForeColor = Color.WhiteSmoke;
            arama_button.BackgroundImage = Properties.Resources.f9bb81e576c1a361c61a8c08945b2c48_search_icon_by_vexels;
            panel16.BackColor = Color.WhiteSmoke;
        }

        private void geri_button_Click(object sender, EventArgs e)
        {
            this.Close();
            yoneticipanel yo = new yoneticipanel();
            yo.Show();
        }

        private void cikis_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kaydet_button_Click(object sender, EventArgs e)
        {
            if (ykayitKitapnoBox.Text != string.Empty && ykayitKitapadextBox.Text != string.Empty && ykayitYazarTextBox.Text != string.Empty && ykayitYayıneviTextBox.Text != string.Empty && ykayitSayfaTextBox.Text != string.Empty  && deneme()
               )
            {
                baglan.Open();

                SqlCommand komut = new SqlCommand("insert into KITAPLAR(KITAP_ID,KITAP_ADI,YAZAR,YAYINEVİ,SAYFA)  values ('" + ykayitKitapnoBox.Text.ToString() + "','"
                + ykayitKitapadextBox.Text.ToString() + "','"
                + ykayitYazarTextBox.Text.ToString() + "','"
                + ykayitYayıneviTextBox.Text.ToString() + "','"
                + ykayitSayfaTextBox.Text.ToString()  +  "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();

                ykayitKitapnoBox.Clear();
                ykayitKitapadextBox.Clear();
                ykayitYazarTextBox.Clear();
                ykayitYayıneviTextBox.Clear();
                ykayitSayfaTextBox.Clear();
                return;
            }

            else if (ykayitKitapnoBox.Text == string.Empty || ykayitKitapadextBox.Text == string.Empty || ykayitYazarTextBox.Text == string.Empty || ykayitYayıneviTextBox.Text == string.Empty || ykayitSayfaTextBox.Text == string.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("Boş alanları doldurunuz!");
                //MessageBox.Show("Boş alanları doldurunuz!", "HATA!");
            }
            baglan.Close();
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

        private void cikis_button_MouseMove(object sender, MouseEventArgs e)
        {
            cikis_button.BackgroundImage = Properties.Resources.exitleave;
            cikis_button.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void cikis_button_MouseLeave(object sender, EventArgs e)
        {
            cikis_button.BackgroundImage = Properties.Resources.exit1;
        }

        private void aramaTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.AcceptButton = arama_button;
            panel16.BackColor = Color.FromArgb(78, 184, 206);
            aramaTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            arama_button.BackgroundImage = Properties.Resources.aramamavi;
        }

        private void kitapislemleri_MouseClick(object sender, MouseEventArgs e)
        {
            panel16.BackColor = Color.WhiteSmoke;
            aramaTextBox.ForeColor = Color.WhiteSmoke;
            arama_button.BackgroundImage = Properties.Resources.f9bb81e576c1a361c61a8c08945b2c48_search_icon_by_vexels;
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            kitapadTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
            ykayitKitapnoBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitKitapadextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitYazarTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitYayıneviTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitSayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
        }

        private void kitapnoTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            kitapnoTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel5.BackColor = Color.FromArgb(78, 184, 206);
            kitapadTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void kitapadTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            kitapadTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel6.BackColor = Color.FromArgb(78, 184, 206);
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void yazarTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            yazarTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel7.BackColor = Color.FromArgb(78, 184, 206);
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void yayineviTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            yayineviTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel8.BackColor = Color.FromArgb(78, 184, 206);
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            kitapadTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void sayfaTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            sayfaTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel9.BackColor = Color.FromArgb(78, 184, 206);
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            kitapadTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
        }

        private void ykayitKitapnoBox_MouseClick(object sender, MouseEventArgs e)
        {
            ykayitKitapnoBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel10.BackColor = Color.FromArgb(78, 184, 206);
            ykayitKitapadextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitYazarTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitYayıneviTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitSayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
        }

        private void ykayitKitapadextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitKitapnoBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("Kitap No alanı boş bırakılamaz.");
                ykayitKitapnoBox.Focus();
                return;
            }

            ykayitKitapadextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel11.BackColor = Color.FromArgb(78, 184, 206);
            ykayitKitapnoBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitYazarTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitYayıneviTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitSayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
        }

        private void ykayitYazarTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitKitapadextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("Kitap Adı alanı boş bırakılamaz.");
                ykayitKitapnoBox.Focus();
                return;
            }

            ykayitYazarTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel12.BackColor = Color.FromArgb(78, 184, 206);
            ykayitKitapnoBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitKitapadextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitYayıneviTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitSayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
        }

        private void ykayitYayıneviTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitYazarTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("Yazar alanı boş bırakılamaz.");
                ykayitKitapnoBox.Focus();
                return;
            }

            ykayitYayıneviTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel13.BackColor = Color.FromArgb(78, 184, 206);
            ykayitKitapnoBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitKitapadextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitYazarTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitSayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
        }

        private void ykayitSayfaTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitYayıneviTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("Yayınevi alanı boş bırakılamaz.");
                ykayitKitapnoBox.Focus();
                return;
            }

            ykayitSayfaTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel14.BackColor = Color.FromArgb(78, 184, 206);
            ykayitKitapnoBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitKitapadextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitYazarTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitYayıneviTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
        }

        private void duzenle_button_MouseClick(object sender, MouseEventArgs e)
        {
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            kitapadTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void sil_button_MouseClick(object sender, MouseEventArgs e)
        {
            kitapnoTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            kitapadTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            yazarTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            yayineviTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            sayfaTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void duzenle_button_MouseMove(object sender, MouseEventArgs e)
        {
            duzenle_button.BackColor = Color.WhiteSmoke;
        }

        private void duzenle_button_MouseLeave(object sender, EventArgs e)
        {
            duzenle_button.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void sil_button_MouseMove(object sender, MouseEventArgs e)
        {
            sil_button.BackColor = Color.WhiteSmoke;
        }

        private void sil_button_MouseLeave(object sender, EventArgs e)
        {
            sil_button.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void kaydet_button_MouseMove(object sender, MouseEventArgs e)
        {
            kaydet_button.BackColor = Color.WhiteSmoke;
        }

        private void kaydet_button_MouseLeave(object sender, EventArgs e)
        {
            kaydet_button.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void duzenle_button_Click(object sender, EventArgs e)
        {
            int x = 0;
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from KITAPLAR", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                if (kitapIslem_List.SelectedItems[0].SubItems[0].Text == tablo.Rows[i]["KITAP_ID"].ToString())
                {
                    x = int.Parse(tablo.Rows[i]["KITAP_ID"].ToString());
                }


            }
            baglan.Close();

            baglan.Open();
            string kayit = "UPDATE KITAPLAR SET KITAP_ID=@KITAP_ID ,KITAP_ADI=@KITAP_ADI,YAZAR=@YAZAR,YAYINEVİ=@YAYINEVİ,SAYFA=@SAYFA where KITAP_ID=" + x + "";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@KITAP_ID", kitapnoTextBox.Text);
            komut.Parameters.AddWithValue("@KITAP_ADI", kitapadTextBox.Text);
            komut.Parameters.AddWithValue("@YAZAR", yazarTextBox.Text);
            komut.Parameters.AddWithValue("@YAYINEVİ", yayineviTextBox.Text);
            komut.Parameters.AddWithValue("@SAYFA", sayfaTextBox.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            uyarı uy = new uyarı();
            uy.l.Text = "Kitap Bilgileri Güncellendi.";
            uy.basarili();
            kitapIslem_List.Items.Clear();
            aramaTextBox.Clear();
            kitapnoTextBox.Clear();
            kitapadTextBox.Clear();
            yazarTextBox.Clear();
            yayineviTextBox.Clear();
            sayfaTextBox.Clear();

        }

        private void sil_button_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM KITAPLAR WHERE KITAP_ID=@KITAP_ID", baglan);
            komut.Parameters.AddWithValue("@KITAP_ID", kitapIslem_List.SelectedItems[0].SubItems[0].Text);
            uyarı uy = new uyarı();
            uy.l.Text = "Silme işleminiz gerçekleşti.";
            uy.basarili();
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();

            kitapIslem_List.Items.Clear();
            aramaTextBox.Clear();
            kitapnoTextBox.Clear();
            kitapadTextBox.Clear();
            yazarTextBox.Clear();
            yayineviTextBox.Clear();
            sayfaTextBox.Clear();

            getir();
        }

        private void kitapIslem_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            kitapnoTextBox.Text = kitapIslem_List.SelectedItems[0].SubItems[0].Text;
            kitapadTextBox.Text = kitapIslem_List.SelectedItems[0].SubItems[1].Text;
            yazarTextBox.Text = kitapIslem_List.SelectedItems[0].SubItems[2].Text;
            yayineviTextBox.Text = kitapIslem_List.SelectedItems[0].SubItems[3].Text;
            sayfaTextBox.Text = kitapIslem_List.SelectedItems[0].SubItems[4].Text;
        }

        private void ykayitKitapadextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitKitapnoBox.Text == String.Empty)
            {
                ykayitKitapadextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitKitapadextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitYazarTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitKitapadextBox.Text == String.Empty)
            {
                ykayitYazarTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitYazarTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitYayıneviTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitYazarTextBox.Text == String.Empty)
            {
                ykayitYayıneviTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitYayıneviTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitSayfaTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitYayıneviTextBox.Text == String.Empty)
            {
                ykayitSayfaTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitSayfaTextBox.Cursor = Cursors.IBeam;
            }
        }
    }
}
