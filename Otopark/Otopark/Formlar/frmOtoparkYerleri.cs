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
    public partial class frmOtoparkYerleri : DevExpress.XtraEditors.XtraForm
    {
        public frmOtoparkYerleri()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();


        private void VeriTabaniParkYerleri()
        {
            var parkyerleri = from i in db.TBLAracParkYerleri
                              select new
                              {
                                  i.Durumu,
                                  i,
                                  i.ID,
                                  i.ParkYerleri,
                              };
            foreach (var item in parkyerleri)
            {
                foreach (Control lbl in panel1.Controls)
                {
                    if (item.Durumu == "BOŞ" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Green;
                    }
                    else if (item.Durumu == "DURUMU" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Black;
                    }
                }
                foreach (Control lbl in panel2.Controls)
                {
                    if (item.Durumu == "BOŞ" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Green;
                    }
                    else if (item.Durumu == "DURUMU" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Black;
                    }
                }

            }
        }

        private void PanelParkYerleri()
        {
            int x = 1, y = 1, z = 11;
            foreach (Control item in panel1.Controls)
            {
                if (item is Label)
                {
                    item.Text = "A-" + x;
                    item.Name = x.ToString();
                    x++;
                }
            }
            foreach (Control item in panel2.Controls)
            {
                if (item is Label)
                {
                    item.Text = "B-" + y;
                    item.Name = z.ToString();
                    y++;
                    z++;
                }
            }
        }


        private void frmOtoparkYerleri_Load(object sender, EventArgs e)
        {
            PanelParkYerleri();
            VeriTabaniParkYerleri();
            var plakagoster = from x in db.TBLAracParkBilgileri
                              select new { x.Plaka, x.ParkYeriID };
            foreach (var item in plakagoster)
            {
                foreach (Control lbl in panel1.Controls)
                {
                    if (lbl.Name == item.ParkYeriID.ToString() && lbl.BackColor == Color.Red)
                    {
                        lbl.Text = item.Plaka;
                    }

                }

                foreach (Control lbl in panel2.Controls)
                {
                    if (lbl.Name == item.ParkYeriID.ToString() && lbl.BackColor == Color.Red)
                    {
                        lbl.Text = item.Plaka;
                    }

                }

            }
        }
    }
}