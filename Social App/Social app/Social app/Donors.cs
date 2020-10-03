using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Social_app
{
    public partial class Donors : UserControl
    {
        private static Donors _instance;

        public static Donors Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Donors();
                return _instance;
            }
        }
        public Donors()
        {
            InitializeComponent();
        }

        private void BunifuTileButton2_Click(object sender, EventArgs e)
        {
            Delete dlg = new Delete();
            dlg.Show();
            dlg.BringToFront();
        }

        private void BunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(NewDonor.Instance))
            {
                panel2.Controls.Add(NewDonor.Instance);
                NewDonor.Instance.Dock = DockStyle.Fill;
                NewDonor.Instance.BringToFront();
            }
            else
                NewDonor.Instance.BringToFront();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuTileButton3_Click(object sender, EventArgs e)
        {

        }

        private void BunifuTileButton4_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(CurrentDonors.Instance))
            {
                panel2.Controls.Add(CurrentDonors.Instance);
                CurrentDonors.Instance.Dock = DockStyle.Fill;
                CurrentDonors.Instance.BringToFront();
            }
            else
                CurrentDonors.Instance.BringToFront();
        }
    }
}
