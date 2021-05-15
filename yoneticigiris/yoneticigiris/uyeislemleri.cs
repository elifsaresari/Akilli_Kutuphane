using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace yoneticigiris
{
    public partial class uyeislemleri : Form
    {
        public uyeislemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6O4GPNU\\SQLEXPRESS;Initial Catalog=akıllı_kutuphane;Integrated Security=True");


        void getir()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from KULLANICILAR", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            int sira;
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                sira = uyeIslem_List.Items.Count;
                if (aramaTextBox.Text == tablo.Rows[i]["TC"].ToString())
                {
                    uyeIslem_List.Items.Add(tablo.Rows[i]["TC"].ToString());
                    uyeIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["AD"].ToString());
                    uyeIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["SOYAD"].ToString());
                    uyeIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["EMAİL"].ToString());
                    uyeIslem_List.Items[sira].SubItems.Add(tablo.Rows[i]["KULLANICI_ADI"].ToString());
                }
            }
            baglan.Close();
        }

        private bool deneme()
        {
            bool x = false; ;
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from KULLANICILAR", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                if (ykayitKullanıcıadiTextBox.Text == tablo.Rows[i]["KULLANICI_ADI"].ToString())
                {
                    uyarı uy = new uyarı();
                    uy.hata("Bu kullanıcı adı alınmış.");
                    ykayitKullanıcıadiTextBox.Focus();
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
        
        private void arama_button_Click(object sender, EventArgs e)
        {
            uyeIslem_List.Items.Clear();
            getir();
            aramaTextBox.ForeColor = Color.WhiteSmoke;
            arama_button.BackgroundImage = Properties.Resources.f9bb81e576c1a361c61a8c08945b2c48_search_icon_by_vexels;
            panel16.BackColor = Color.WhiteSmoke;

        }

        private void kaydet_button_Click(object sender, EventArgs e)
        {         
            if (ykayitTcTextBox.Text != string.Empty && ykayitAdTextBox.Text != string.Empty && ykayitSoyadTextBox.Text != string.Empty && ykayitEmailTextBox.Text != string.Empty && ykayitKullanıcıadiTextBox.Text != string.Empty && ykayitSifreTextBox.Text != string.Empty && deneme()
               )
            {                
                baglan.Open();

                SqlCommand komut = new SqlCommand("insert into KULLANICILAR(TC,AD,SOYAD,EMAİL,KULLANICI_ADI,ŞİFRE)  values ('" + ykayitTcTextBox.Text.ToString() + "','"
                + ykayitAdTextBox.Text.ToString() + "','"
                + ykayitSoyadTextBox.Text.ToString() + "','"
                + ykayitEmailTextBox.Text.ToString() + "','"
                + ykayitKullanıcıadiTextBox.Text.ToString() + "','"
                + ykayitSifreTextBox.Text.ToString() + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();

                ykayitTcTextBox.Clear();
                ykayitAdTextBox.Clear();
                ykayitSoyadTextBox.Clear();
                ykayitEmailTextBox.Clear();
                ykayitKullanıcıadiTextBox.Clear();
                ykayitSifreTextBox.Clear();
                return;
            }

            else if(ykayitTcTextBox.Text == string.Empty || ykayitAdTextBox.Text == string.Empty || ykayitSoyadTextBox.Text == string.Empty || ykayitEmailTextBox.Text == string.Empty  || ykayitKullanıcıadiTextBox.Text == string.Empty || ykayitSifreTextBox.Text == string.Empty 
               )
            {
                uyarı uy = new uyarı();
                uy.hata("Boş alanları doldurunuz!");
            }
            baglan.Close();                       
        }

        private void duzenle_button_Click(object sender, EventArgs e)
        {
            int x=0;
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from KULLANICILAR", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                if (uyeIslem_List.SelectedItems[0].SubItems[0].Text == tablo.Rows[i]["TC"].ToString())
                {
                    x =int.Parse( tablo.Rows[i]["ID"].ToString());
                }

               
            }
            baglan.Close();
            
            baglan.Open();
            string kayit = "UPDATE KULLANICILAR SET TC=@TC ,AD=@AD,SOYAD=@SOYAD,EMAİL=@EMAİL,KULLANICI_ADI=@KULLANICI_ADI where ID=" + x + "";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@TC", tcTextBox.Text);
            komut.Parameters.AddWithValue("@Ad", adTextBox.Text);
            komut.Parameters.AddWithValue("@SOYAD", soyadTextBox.Text);
            komut.Parameters.AddWithValue("@EMAİL", emailTextBox.Text);
            komut.Parameters.AddWithValue("@KULLANICI_ADI", kullanıcıadıTextBox.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            uyarı uy = new uyarı();
            uy.l.Text = "Üye Bilgileri Güncellendi.";
            uy.basariliyonetici();
            uyeIslem_List.Items.Clear();
            aramaTextBox.Clear();
            tcTextBox.Clear();
            adTextBox.Clear();
            soyadTextBox.Clear();
            emailTextBox.Clear();
            kullanıcıadıTextBox.Clear();

        }

        private void cikis_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geri_button_Click(object sender, EventArgs e)
        {
            this.Close();
            yoneticipanel yo = new yoneticipanel();
            yo.Show();            
        }

        private void uyeIslem_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tcTextBox.Text = uyeIslem_List.SelectedItems[0].SubItems[0].Text;
            adTextBox.Text = uyeIslem_List.SelectedItems[0].SubItems[1].Text;
            soyadTextBox.Text = uyeIslem_List.SelectedItems[0].SubItems[2].Text;
            emailTextBox.Text = uyeIslem_List.SelectedItems[0].SubItems[3].Text;
            kullanıcıadıTextBox.Text = uyeIslem_List.SelectedItems[0].SubItems[4].Text;
        }

        private void sil_button_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("DELETE FROM KULLANICILAR WHERE TC=@TC", baglan);
            komut.Parameters.AddWithValue("@TC", uyeIslem_List.SelectedItems[0].SubItems[0].Text);
            uyarı u = new uyarı();
            u.l.Text = "Silme işleminiz gerçekleşti.";
            u.basarili();
            //MessageBox.Show("Silme işleminiz gerçekleşti.");

            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();

            tcTextBox.Clear();
            adTextBox.Clear();
            soyadTextBox.Clear();
            emailTextBox.Clear();
            kullanıcıadıTextBox.Clear();
            aramaTextBox.Clear();

            uyeIslem_List.Items.Clear();
            getir();

        }

        private void ykayitAdTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitTcTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("TC alanı boş bırakılamaz.");
                ykayitTcTextBox.Focus();
                return;
            }

            ykayitAdTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel11.BackColor = Color.FromArgb(78, 184, 206);
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;
        }

        private void ykayitAdTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitTcTextBox.Text == String.Empty)
            {
                ykayitAdTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitAdTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitSoyadTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitAdTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("AD alanı boş bırakılamaz.");
                ykayitAdTextBox.Focus();
                return;
            }
            ykayitSoyadTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel12.BackColor = Color.FromArgb(78, 184, 206);
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;
        }

        private void ykayitSoyadTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitAdTextBox.Text == String.Empty)
            {
                ykayitSoyadTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitSoyadTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitEmailTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitSoyadTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("SOYAD alanı boş bırakılamaz.");
                ykayitSoyadTextBox.Focus();
                return;
            }
            ykayitEmailTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel13.BackColor = Color.FromArgb(78, 184, 206);
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;
        }

        private void ykayitEmailTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitSoyadTextBox.Text == String.Empty)
            {
                ykayitEmailTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitEmailTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitKullanıcıadiTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitEmailTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("E-MAİL alanı boş bırakılamaz.");
                ykayitEmailTextBox.Focus();
                return;
            }
            ykayitKullanıcıadiTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel14.BackColor = Color.FromArgb(78, 184, 206);
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;
        }

        private void ykayitKullanıcıadiTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitEmailTextBox.Text == String.Empty)
            {
                ykayitKullanıcıadiTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitKullanıcıadiTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void ykayitSifreTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ykayitKullanıcıadiTextBox.Text == String.Empty)
            {
                uyarı uy = new uyarı();
                uy.hata("KULLANICI ADI alanı boş bırakılamaz.");
                ykayitKullanıcıadiTextBox.Focus();
                return;
            }
            ykayitSifreTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel15.BackColor = Color.FromArgb(78, 184, 206);
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
        }

        private void ykayitSifreTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ykayitKullanıcıadiTextBox.Text == String.Empty)
            {
                ykayitSifreTextBox.Cursor = Cursors.No;
            }

            else
            {
                ykayitSifreTextBox.Cursor = Cursors.IBeam;
            }
        }

        private void aramaTextBox_MouseClick(object sender, MouseEventArgs e)
        {        
            this.AcceptButton = arama_button;
            panel16.BackColor = Color.FromArgb(78, 184, 206);
            aramaTextBox.ForeColor=Color.FromArgb(78, 184, 206);
            arama_button.BackgroundImage = Properties.Resources.aramamavi;

        }

        private void aramaTextBox_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = arama_button;
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

        private void uyeislemleri_MouseClick(object sender, MouseEventArgs e)
        {
            panel16.BackColor = Color.WhiteSmoke;
            aramaTextBox.ForeColor = Color.WhiteSmoke;
            arama_button.BackgroundImage = Properties.Resources.f9bb81e576c1a361c61a8c08945b2c48_search_icon_by_vexels;
            tcTextBox.ForeColor = Color.WhiteSmoke; 
            panel5.BackColor = Color.WhiteSmoke; 
            adTextBox.ForeColor = Color.WhiteSmoke; 
            panel6.BackColor = Color.WhiteSmoke; 
            soyadTextBox.ForeColor = Color.WhiteSmoke; 
            panel7.BackColor = Color.WhiteSmoke; 
            emailTextBox.ForeColor = Color.WhiteSmoke; 
            panel8.BackColor = Color.WhiteSmoke; 
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke; 
            panel9.BackColor = Color.WhiteSmoke;
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;
        }

        private void tcTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            tcTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel5.BackColor = Color.FromArgb(78, 184, 206);
            adTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            soyadTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            emailTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void adTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            adTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel6.BackColor = Color.FromArgb(78, 184, 206);
            tcTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            soyadTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            emailTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void soyadTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            soyadTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel7.BackColor = Color.FromArgb(78, 184, 206);
            tcTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            adTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            emailTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void emailTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            emailTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel8.BackColor = Color.FromArgb(78, 184, 206);
            tcTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            adTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            soyadTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke;
            panel9.BackColor = Color.WhiteSmoke;
        }

        private void kullanıcıadıTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            kullanıcıadıTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel9.BackColor = Color.FromArgb(78, 184, 206);
            tcTextBox.ForeColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            adTextBox.ForeColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            soyadTextBox.ForeColor = Color.WhiteSmoke;
            panel7.BackColor = Color.WhiteSmoke;
            emailTextBox.ForeColor = Color.WhiteSmoke;
            panel8.BackColor = Color.WhiteSmoke;
        }

        private void duzenle_button_MouseClick(object sender, MouseEventArgs e)
        {
            tcTextBox.ForeColor = Color.WhiteSmoke; 
            panel5.BackColor = Color.WhiteSmoke; 
            adTextBox.ForeColor = Color.WhiteSmoke; 
            panel6.BackColor = Color.WhiteSmoke; 
            soyadTextBox.ForeColor = Color.WhiteSmoke; 
            panel7.BackColor = Color.WhiteSmoke; 
            emailTextBox.ForeColor = Color.WhiteSmoke; 
            panel8.BackColor = Color.WhiteSmoke; 
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke; 
            panel9.BackColor = Color.WhiteSmoke; 
        }

        private void sil_button_MouseClick(object sender, MouseEventArgs e)
        {
            tcTextBox.ForeColor = Color.WhiteSmoke; 
            panel5.BackColor = Color.WhiteSmoke; 
            adTextBox.ForeColor = Color.WhiteSmoke; 
            panel6.BackColor = Color.WhiteSmoke; 
            soyadTextBox.ForeColor = Color.WhiteSmoke; 
            panel7.BackColor = Color.WhiteSmoke; 
            emailTextBox.ForeColor = Color.WhiteSmoke; 
            panel8.BackColor = Color.WhiteSmoke; 
            kullanıcıadıTextBox.ForeColor = Color.WhiteSmoke; 
            panel9.BackColor = Color.WhiteSmoke; 
        }

        private void ykayitTcTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ykayitTcTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            panel10.BackColor = Color.FromArgb(78, 184, 206);
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;
        }

        private void kaydet_button_MouseClick(object sender, MouseEventArgs e)
        {
            ykayitTcTextBox.ForeColor = Color.WhiteSmoke;
            panel10.BackColor = Color.WhiteSmoke;
            ykayitAdTextBox.ForeColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            ykayitSoyadTextBox.ForeColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            ykayitEmailTextBox.ForeColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
            ykayitKullanıcıadiTextBox.ForeColor = Color.WhiteSmoke;
            panel14.BackColor = Color.WhiteSmoke;
            ykayitSifreTextBox.ForeColor = Color.WhiteSmoke;
            panel15.BackColor = Color.WhiteSmoke;

        }

        private void kaydet_button_MouseMove(object sender, MouseEventArgs e)
        {
            kaydet_button.BackColor = Color.WhiteSmoke;
        }

        private void kaydet_button_MouseLeave(object sender, EventArgs e)
        {
            kaydet_button.BackColor = Color.FromArgb(78, 184, 206);
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
    }
    }
    

