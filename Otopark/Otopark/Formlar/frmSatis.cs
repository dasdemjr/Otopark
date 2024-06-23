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
    public partial class frmSatis : DevExpress.XtraEditors.XtraForm
    {
        public frmSatis()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void TumKayitlar()
        {
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).ToList();
            dataGridView1.DataSource = Liste;
        }


        private void frmSatis_Load(object sender, EventArgs e)
        {
            #region KayitGoster
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).ToList();
            dataGridView1.DataSource = Liste;
            lblTutar.Text = "Toplam Tutar=" + db.TBLSatis.Sum(x => x.Tutar);
            lblKayit.Text = "Toplam" + db.TBLSatis.Count() + "Kayıt Liselendi.";
            lblOrtalama.Text = "Ortalama Tutar=" + db.TBLSatis.Average(x => x.Tutar);
            lblMax.Text = "En Yüksek Tutar=" + db.TBLSatis.Max(x => x.Tutar);
            lblMin.Text = "En Düşük Tutar=" + db.TBLSatis.Min(x => x.Tutar);
            #endregion
        }

        private void txtIDAra_TextChanged(object sender, EventArgs e)
        {
            #region IDAra
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).Where(x => x.ID.ToString() == txtIDAra.Text).ToList();
            dataGridView1.DataSource = Liste;
            if (txtIDAra.Text == "")
            {
                TumKayitlar();
            }
            #endregion  
        }

        private void txtMusteriIDAra_TextChanged(object sender, EventArgs e)
        {
            #region MusteriIDAra
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).Where(x => x.MusteriID.ToString() == txtMusteriIDAra.Text).ToList();
            dataGridView1.DataSource = Liste;
            if (txtMusteriIDAra.Text == "")
            {
                TumKayitlar();
            }
            #endregion  
        }

        private void txtAdSoyadAra_TextChanged(object sender, EventArgs e)
        {
            #region AdSoyadAra
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).Where(x => x.AdiSoyadi.Contains(txtAdSoyadAra.Text)).ToList();
            dataGridView1.DataSource = Liste;
            lblTutar.Text = "Toplam Tutar=" + db.TBLSatis.Sum(x => x.Tutar);
            lblKayit.Text = "Toplam" + db.TBLSatis.Count() + "Kayıt Liselendi.";
            lblOrtalama.Text = "Ortalama Tutar=" + db.TBLSatis.Average(x => x.Tutar);
            lblMax.Text = "En Yüksek Tutar=" + db.TBLSatis.Max(x => x.Tutar);
            lblMin.Text = "En Düşük Tutar=" + db.TBLSatis.Min(x => x.Tutar);
            #endregion  
        }

        private void txtPlakaAra_TextChanged(object sender, EventArgs e)
        {
            #region PlakaAra
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).Where(x => x.Plaka.Contains(txtPlakaAra.Text)).ToList();
            dataGridView1.DataSource = Liste;
            lblTutar.Text = "Toplam Tutar=" + db.TBLSatis.Sum(x => x.Tutar);
            lblKayit.Text = "Toplam" + db.TBLSatis.Count() + "Kayıt Liselendi.";
            lblOrtalama.Text = "Ortalama Tutar=" + db.TBLSatis.Average(x => x.Tutar);
            lblMax.Text = "En Yüksek Tutar=" + db.TBLSatis.Max(x => x.Tutar);
            lblMin.Text = "En Düşük Tutar=" + db.TBLSatis.Min(x => x.Tutar);
            #endregion  
        }

        private void txtParkYeriAra_TextChanged(object sender, EventArgs e)
        {
            #region ParkYeriAra
            var Liste = (from x in db.TBLSatis
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                join z in db.TBLSeri on x.SeriID equals z.ID
                join
                    w in db.TBLAracParkYerleri on x.ParkYeriID equals w.ID
                select new
                {
                    x.ID,
                    x.SatisID,
                    x.MusteriID,
                    x.AdiSoyadi,
                    x.Telefon,
                    w.ParkYerleri,
                    y.MarkaAdi,
                    z.seri,
                    x.Plaka,
                    x.Yil,
                    x.Renk,
                    x.ACiklama,
                    x.SaatUCreti,
                    x.Sure,
                    x.Tutar,
                    x.GirisTarihi,

                }).Where(x => x.ParkYerleri.Contains(txtParkYeriAra.Text)).ToList();
            dataGridView1.DataSource = Liste;
            lblTutar.Text = "Toplam Tutar=" + db.TBLSatis.Sum(x => x.Tutar);
            lblKayit.Text = "Toplam" + db.TBLSatis.Count() + "Kayıt Liselendi.";
            lblOrtalama.Text = "Ortalama Tutar=" + db.TBLSatis.Average(x => x.Tutar);
            lblMax.Text = "En Yüksek Tutar=" + db.TBLSatis.Max(x => x.Tutar);
            lblMin.Text = "En Düşük Tutar=" + db.TBLSatis.Min(x => x.Tutar);
            #endregion  
        }
    }
}