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
    public partial class frmMarka : DevExpress.XtraEditors.XtraForm
    {
        public frmMarka()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void MarkaListele()
        {
            listView1.Items.Clear();
            var markalistesi = db.TBLMarka.ToList();
            for (int i = 0; i < markalistesi.Count; i++)
            {
                ListViewItem ekle = new ListViewItem(markalistesi[i].ID.ToString());
                ekle.SubItems.Add(markalistesi[i].MarkaAdi);
                listView1.Items.Add(ekle);
            }
        }
        void temizle()
        {
            TxtID.Text = "";
            TxtMarkaAdi.Text = "";
        }


        private void frmMarka_Load(object sender, EventArgs e)
        {
            MarkaListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var tbl = new Marka();
            tbl.MarkaAdi = TxtMarkaAdi.Text;
            db.TBLMarka.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("Marka Eklendi", "kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MarkaListele();
            temizle();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                TxtID.Text = secilen.SubItems[0].Text;
                TxtMarkaAdi.Text = secilen.SubItems[1].Text;

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ListViewItem secilenID = listView1.SelectedItems[0];
            int SecilenID = int.Parse(secilenID.SubItems[0].Text);
            var sil = db.TBLMarka.FirstOrDefault(x => x.ID == SecilenID);
            db.TBLMarka.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Marka Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MarkaListele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var guncelle = db.TBLMarka.FirstOrDefault(x => x.ID == id);
            guncelle.MarkaAdi = TxtMarkaAdi.Text;
            db.SaveChanges();
            MessageBox.Show("Marka Güncellendi", "Güncel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MarkaListele();
            temizle();
        }
    }
}