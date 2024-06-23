using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Windows.Forms;
using Otopark.Formlar;

namespace Otopark
{
    public partial class frmAnaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void MarkaTool_Click(object sender, EventArgs e)
        {
            frmMarka frm = new frmMarka();
            frm.Show();
        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMusteriListele frm = new frmMusteriListele();
            frm.Show();
        }

        private void brnMusterilistesi_Click(object sender, EventArgs e)
        {
            frmMusteriListele frm = new frmMusteriListele();
            frm.Show();
        }

        private void araçOtoparkGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAracOtoparkGirisi frm = new frmAracOtoparkGirisi();
            frm.Show();
        }

        private void araçOtopakÇıkışıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAracOtoparkCikisi frm = new frmAracOtoparkCikisi();
            frm.Show();
        }

        private void seriTool_Click(object sender, EventArgs e)
        {
            frmSeri frm = new frmSeri();
            frm.Show();
        }

        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSatis frm = new frmSatis();
            frm.Show();
        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAracOtoparkGirisi_Click(object sender, EventArgs e)
        {
            frmAracOtoparkGirisi frm = new frmAracOtoparkGirisi();
            frm.Show();
        }

        private void btnAracOtoparkCikisi_Click(object sender, EventArgs e)
        {
            frmAracOtoparkCikisi frm = new frmAracOtoparkCikisi();
            frm.Show();
        }

        private void btnOtoparkYerleri_Click(object sender, EventArgs e)
        {
            frmOtoparkYerleri frm = new frmOtoparkYerleri();
            frm.Show();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            frmSatis frm = new frmSatis();
            frm.Show();
        }

        private void brnMarka_Click(object sender, EventArgs e)
        {
            frmMarka frm = new frmMarka();
            frm.Show();
        }

        private void btnSeri_Click(object sender, EventArgs e)
        {
            frmSeri frm = new frmSeri();
            frm.Show();
        }
    }
}
