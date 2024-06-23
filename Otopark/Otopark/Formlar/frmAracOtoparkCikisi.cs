using DevExpress.XtraEditors;
using Otopark.Classlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = DevExpress.XtraEditors.ComboBox;

namespace Otopark.Formlar
{
    public partial class frmAracOtoparkCikisi : DevExpress.XtraEditors.XtraForm
    {
        public frmAracOtoparkCikisi()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void Yenile()
        {
            comboPlakaAra.Text = "";
            comboPlakaAra.Items.Clear();
            var plakagetir = db.TBLAracParkBilgileri.ToList();
            foreach (var item in plakagetir)
            {
                comboPlakaAra.Items.Add(item.Plaka);
            }
            var bosparkyerleri = db.TBLAracParkYerleri.Where(x => x.Durumu == "Boş").ToList();
            comboParkYeri.DataSource = bosparkyerleri;
            comboParkYeri.DisplayMember = "ParkYerleri";
            comboParkYeri.ValueMember = "ID";
            var Doluparkyerleri = db.TBLAracParkYerleri.Where(x => x.Durumu == "Dolu").ToList();
            comboParkYeriAra.DataSource = Doluparkyerleri;
            comboParkYeriAra.DisplayMember = "ParkYerleri";
            comboParkYeriAra.ValueMember = "ID";
            comboParkYeriAra.ValueMember = "ID";
            comboParkYeriAra.Text = "";
            comboParkYeri.Text = "";
        }

        void ucretHesapla()
        {
            try
            {
                lblCikisTarihi.Text = DateTime.Now.ToString();
                TimeSpan fark;
                fark = DateTime.Parse(lblCikisTarihi.Text) - DateTime.Parse(lblGirisTarihi.Text);
                decimal saatUcreti = 0, sure = 0, tutar = 0;
                lblSure.Text = fark.TotalHours.ToString();
                saatUcreti = decimal.Parse(lblSure.Text);
                tutar = sure * saatUcreti;
                lblUcret.Text = tutar.ToString("0.00");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void KayitSil()
        {
            var sil = db.TBLAracParkBilgileri.FirstOrDefault(x => x.Plaka == txtPlaka.Text);
            db.TBLAracParkBilgileri.Remove(sil);
            db.SaveChanges();

            var aracparkyeribosalt = db.TBLAracParkYerleri.FirstOrDefault(x => x.ParkYerleri == comboParkYeri.Text);
            aracparkyeribosalt.Durumu = "Boş";
            db.SaveChanges();
        }

        private void frmAracOtoparkCikisi_Load(object sender, EventArgs e)
        {
            comboSaatUcreti.SelectedIndex = 0;
            Yenile();
            var markagetir = db.TBLMarka.ToList();
            comboMarka.DataSource = markagetir;
            comboMarka.DisplayMember = "MarkaAdi";
            comboMarka.ValueMember = "ID";
        }

        private void comboMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var serigetir = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedIndex).ToList();
                comboSeri.DataSource = serigetir;
                comboSeri.DisplayMember = "Seri";
                comboSeri.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboMarka_ValueMemberChanged(object sender, EventArgs e)
        {
            var serigetir = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedIndex).ToList();
            comboSeri.DataSource = serigetir;
            comboSeri.DisplayMember = "Seri";
            comboSeri.ValueMember = "ID";
        }

        private void txtIDAra_TextChanged(object sender, EventArgs e)
        {
            if (txtIDAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            #region IDara
            var IDAra = (from x in db.TBLAracParkBilgileri
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    x.Plaka,
                    x.Renk,
                    x.ACiklama,
                    x.GirisTarihi,
                    y.MarkaAdi,
                    z.seri,
                    w.ParkYerleri
                }).Where(ara => ara.ID.ToString() == txtIDAra.Text).ToList();
            foreach (var item in IDAra)
            {
                txtID.Text = item.ID.ToString();
                txtMusteriID.Text = item.MusteriID.ToString();
                txtAdSoyad.Text = item.AdiSoyadi;
                txtTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                txtPlaka.Text = item.Plaka;
                txtRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                txtAciklama.Text = item.ACiklama;
                lblGirisTarihi.Text = item.GirisTarihi.ToString();
                ucretHesapla();

            }
            #endregion
        }

        private void txtMusteriIDAra_TextChanged(object sender, EventArgs e)
        {
            if (txtMusteriID.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            #region MusteriIDara
            var MusteriIDAra = (from x in db.TBLAracParkBilgileri
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    x.Plaka,
                    x.Renk,
                    x.ACiklama,
                    x.GirisTarihi,
                    y.MarkaAdi,
                    z.seri,
                    w.ParkYerleri
                }).Where(ara => ara.MusteriID.ToString() == txtMusteriIDAra.Text).ToList();
            foreach (var item in MusteriIDAra)
            {
                txtID.Text = item.ID.ToString();
                txtMusteriID.Text = item.MusteriID.ToString();
                txtAdSoyad.Text = item.AdiSoyadi;
                txtTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                txtPlaka.Text = item.Plaka;
                txtRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                txtAciklama.Text = item.ACiklama;
                lblGirisTarihi.Text = item.GirisTarihi.ToString();
                ucretHesapla();

            }
            #endregion
        }

        private void txtAdSoyadAra_TextChanged(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            #region AdSoyadAra
            var AdSoyadAra = (from x in db.TBLAracParkBilgileri
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    x.Plaka,
                    x.Renk,
                    x.ACiklama,
                    x.GirisTarihi,
                    y.MarkaAdi,
                    z.seri,
                    w.ParkYerleri
                }).Where(ara => ara.AdiSoyadi.ToString() == txtAdSoyad.Text).ToList();
            foreach (var item in AdSoyadAra)
            {
                txtID.Text = item.ID.ToString();
                txtMusteriID.Text = item.MusteriID.ToString();
                txtAdSoyad.Text = item.AdiSoyadi;
                txtTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                txtPlaka.Text = item.Plaka;
                txtRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                txtAciklama.Text = item.ACiklama;
                lblGirisTarihi.Text = item.GirisTarihi.ToString();
                ucretHesapla();
            }
            #endregion
        }

        private void comboPlakaAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region PlakaAra
            var PlakaAra = (from x in db.TBLAracParkBilgileri
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    x.Plaka,
                    x.Renk,
                    x.ACiklama,
                    x.GirisTarihi,
                    y.MarkaAdi,
                    z.seri,
                    w.ParkYerleri
                }).Where(ara => ara.Plaka.ToString() == comboPlakaAra.Text).ToList();
            foreach (var item in PlakaAra)
            {
                txtID.Text = item.ID.ToString();
                txtMusteriID.Text = item.MusteriID.ToString();
                txtAdSoyad.Text = item.AdiSoyadi;
                txtTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                txtPlaka.Text = item.Plaka;
                txtRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                txtAciklama.Text = item.ACiklama;
                lblGirisTarihi.Text = item.GirisTarihi.ToString();
                ucretHesapla();

            }
            #endregion
        }

        private void comboParkYeriAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ParkYeri
            var ParkYeriAra = (from x in db.TBLAracParkBilgileri
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    x.Plaka,
                    x.Renk,
                    x.ACiklama,
                    x.GirisTarihi,
                    y.MarkaAdi,
                    z.seri,
                    w.ParkYerleri
                }).Where(ara => ara.ParkYerleri.ToString() == comboParkYeri.Text).ToList();
            foreach (var item in ParkYeriAra)
            {
                txtID.Text = item.ID.ToString();
                txtMusteriID.Text = item.MusteriID.ToString();
                txtAdSoyad.Text = item.AdiSoyadi;
                txtTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                txtPlaka.Text = item.Plaka;
                txtRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                txtAciklama.Text = item.ACiklama;
                lblGirisTarihi.Text = item.GirisTarihi.ToString();
                ucretHesapla();

            }
            #endregion
        }

        private void comboPlakaAra_TextChanged(object sender, EventArgs e)
        {
            if (comboPlakaAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void comboParkYeriAra_TextChanged(object sender, EventArgs e)
        {
            if (comboPlakaAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void btnParkYeriGuncelle_Click(object sender, EventArgs e)
        {
            var DoluParkYeriDegistir = db.TBLAracParkYerleri.FirstOrDefault(x => x.ParkYerleri == comboParkYeriAra.Text);
            DoluParkYeriDegistir.Durumu = "Boş";
            var BoşParkYeriDegistir = db.TBLAracParkYerleri.FirstOrDefault(x => x.ParkYerleri == comboParkYeri.Text);
            DoluParkYeriDegistir.Durumu = "Dolu";
            db.SaveChanges();
            var aracparkyeridegistir = db.TBLAracParkBilgileri.FirstOrDefault(x => x.Plaka == txtPlaka.Text);
            aracparkyeridegistir.ParkYeriID = (int)comboParkYeri.SelectedValue;
            db.SaveChanges();
            MessageBox.Show("Araç Park Yeri Güncellendii", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboParkYeriAra.Items.Clear();
            Yenile();
            btnTemizle.PerformClick();
            lblSure.Text = "0.00";
            lblUcret.Text = "0.00";
            lblGirisTarihi.Text = DateTime.Now.ToString();
            lblCikisTarihi.Text = DateTime.Now.ToString();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in panelArama.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in panelBilgiler.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            lblSure.Text = "0.00";
            lblUcret.Text = "0.00";
            lblGirisTarihi.Text = DateTime.Now.ToString();
            lblCikisTarihi.Text = DateTime.Now.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            #region Sil
            KayitSil();
            #endregion
            MessageBox.Show("Araç Park Yeri Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboParkYeriAra.Items.Clear();
            Yenile();
            btnTemizle.PerformClick();
            lblSure.Text = "0.00";
            lblUcret.Text = "0.00";
            lblGirisTarihi.Text = DateTime.Now.ToString();
            lblCikisTarihi.Text = DateTime.Now.ToString();
        }

        private void panelİslemler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAracCikis_Click(object sender, EventArgs e)
        {
            #region AracCikisi
            if (comboParkYeriAra.Text != "")
            {
                var ekle = new Satis();
                ekle.SatisID = int.Parse(txtID.Text);
                ekle.MusteriID = int.Parse(txtMusteriID.Text);
                ekle.AdiSoyadi = txtAdSoyad.Text;
                ekle.Telefon = txtTelefon.Text;
                ekle.MarkaID = (int)comboMarka.SelectedValue;
                ekle.SeriID = (int)comboSeri.SelectedValue;
                ekle.Plaka = txtPlaka.Text;
                ekle.Yil = "Belirtilmedi";
                ekle.Renk = txtRenk.Text;
                ekle.ParkYeriID = (int)comboParkYeriAra.SelectedValue;
                ekle.SaatUCreti = decimal.Parse(comboSaatUcreti.Text);
                ekle.Sure = decimal.Parse(lblSure.Text);
                ekle.Tutar = decimal.Parse(lblUcret.Text);
                ekle.ACiklama = txtAciklama.Text;
                ekle.GirisTarihi = DateTime.Parse(lblGirisTarihi.Text);
                ekle.CikisTarihi = DateTime.Parse(lblCikisTarihi.Text);
                db.TBLSatis.Add(ekle);
                db.SaveChanges();
                MessageBox.Show("Araç Çıkışı Yapıldı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KayitSil();
                Yenile();
                btnTemizle.PerformClick();
                lblSure.Text = "0.00";
                lblUcret.Text = "0.00";
                lblGirisTarihi.Text = DateTime.Now.ToString();
                lblCikisTarihi.Text = DateTime.Now.ToString();
            }
            else
            {
                MessageBox.Show("Dolu ParkYerinin Seçilmesi Gerekir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            #endregion
            MessageBox.Show("Araç Çıkışı Yapıldı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboParkYeriAra.Items.Clear();
            Yenile();
            btnTemizle.PerformClick();
        }

        private void comboSaatUcreti_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucretHesapla();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var guncelle = db.TBLAracParkBilgileri.FirstOrDefault(x => x.ID.ToString() == txtID.Text);
            guncelle.MarkaID = (int)comboMarka.SelectedValue;
            guncelle.SeriID = (int)comboSeri.SelectedValue;
            guncelle.Plaka = txtPlaka.Text;
            guncelle.Renk = txtRenk.Text;
            guncelle.ACiklama = txtAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Araç Güncellendi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Yenile();
            btnTemizle.PerformClick();
            lblSure.Text = "0.00";
            lblUcret.Text = "0.00";
            lblGirisTarihi.Text = DateTime.Now.ToString();
            lblCikisTarihi.Text = DateTime.Now.ToString();
        }
    }
}