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

namespace Otopark.Formlar
{
    public partial class frmAracOtoparkGirisi : DevExpress.XtraEditors.XtraForm
    {
        public frmAracOtoparkGirisi()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void ParkYeriYenile()
        {
            var parkyerlerigetir = db.TBLAracParkYerleri.Where(x => x.Durumu == "BOŞ").ToList();
            comboParkYerleri.DataSource = parkyerlerigetir;
            comboParkYerleri.DisplayMember = "ParkYerleri";
            comboParkYerleri.ValueMember = "ID";
        }

        private void frmAracOtoparkGirisi_Load(object sender, EventArgs e)
        {
            var markagetir = db.TBLMarka.ToList();
            comboMarka.DataSource = markagetir;
            comboMarka.DataSource = markagetir;
            comboMarka.DisplayMember = "MarkaAdi";
            comboMarka.ValueMember = "ID";

            ParkYeriYenile();
        }

        private void comboMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var serigetir = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedValue).ToList();
                comboMarka.DataSource = serigetir;
                comboMarka.DisplayMember = "Seri";
                comboMarka.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMusteriID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var MusteriGetir = db.TBLMusteri.Where(x => x.ID.ToString() == txtMusteriID.Text).ToList();
                foreach (var item in MusteriGetir)
                {
                    txtAdSoyad.Text = item.AdiSoyadi;
                    txtTelefon.Text = item.Telefon;
                }
                if (txtMusteriID.Text == "")
                {
                    txtAdSoyad.Text = "";
                    txtTelefon.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
        }

        private void bnKaydet_Click(object sender, EventArgs e)
        {
            var ekle = new AracParkBilgileri();
            ekle.MusteriID = int.Parse(txtMusteriID.Text);
            ekle.AdiSoyadi = txtMusteriID.Text;
            ekle.Telefon = txtTelefon.Text;
            ekle.MarkaID = (int)comboMarka.SelectedValue;
            ekle.SeriID = (int)comboSeri.SelectedValue;
            ekle.Yil = txtYil.Text;
            ekle.Renk = txtRenk.Text;
            ekle.ParkYeriID = (int)comboParkYerleri.SelectedValue;
            ekle.ACiklama = txtAciklama.Text;
            ekle.GirisTarihi = DateTime.Now;
            db.TBLAracParkBilgileri.Add(ekle);
            db.SaveChanges();

            var parkyeridoldur = db.TBLAracParkYerleri.FirstOrDefault(x => x.ID == (int)comboParkYerleri.SelectedValue);
            parkyeridoldur.Durumu = "Dolu";
            db.SaveChanges();
            MessageBox.Show("Kayıt İşlemi Başarılı.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnTemizle.PerformClick();
            ParkYeriYenile();
        }
    }
}