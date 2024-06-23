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
    public partial class frmSeri : DevExpress.XtraEditors.XtraForm
    {
        public frmSeri()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void Listele()
        {
            listView1.Items.Clear();
            var liste = from x in db.TBLSeri
                join y in db.TBLMarka on
                    x.MarkaID equals y.ID
                select new
                {
                    x.ID,
                    y.MarkaAdi,
                    x.seri
                };
            foreach (var item in liste)
            {
                ListViewItem ViewItem = new ListViewItem(item.ID.ToString());
                ViewItem.SubItems.Add(item.MarkaAdi);
                ViewItem.SubItems.Add(item.seri);
                listView1.Items.Add(ViewItem);
            }
        }
        void temizle()
        {
            txtID.Text = "";
            txtSeri.Text = "";
            comboMarka.Text = "";
        }

        private void frmSeri_Load(object sender, EventArgs e)
        {
            Listele();
            var comboliste = db.TBLMarka.ToList();
            comboMarka.DataSource = comboliste;
            comboMarka.DisplayMember = "MarkaAdi";
            comboMarka.ValueMember = "ID";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int markaid = (int)comboMarka.SelectedIndex;
            var ekle = new Seri();
            ekle.MarkaID = markaid;
            ekle.seri = txtSeri.Text;
            db.TBLSeri.Add(ekle);
            db.SaveChanges();
            temizle();
            Listele();
            MessageBox.Show("Araca Yeni Seri Eklendi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ListViewItem secilenID = listView1.SelectedItems[0];
            int SecilenID = int.Parse(secilenID.SubItems[0].Text);
            var sil = db.TBLSeri.FirstOrDefault(x => x.ID == SecilenID);
            db.TBLSeri.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Seri Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var guncelle = db.TBLSeri.FirstOrDefault(x => x.ID == id);
            guncelle.MarkaID = (int)comboMarka.SelectedValue;
            guncelle.seri = txtSeri.Text;
            db.SaveChanges();
            MessageBox.Show("Seri Güncellendi", "Güncel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                txtID.Text = secilen.SubItems[0].Text;
                comboMarka.Text = secilen.SubItems[1].Text;
                txtSeri.Text = secilen.SubItems[2].Text;

            }
        }
    }
}