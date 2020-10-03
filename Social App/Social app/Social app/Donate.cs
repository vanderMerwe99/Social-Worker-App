using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Social_app
{
    public partial class Donate : UserControl
    {
        private static Donate _instance;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\brand\OneDrive\Desktop\Year 2\CMPG 223\Social app\Social app\Info.mdf;Integrated Security=True");

        public static Donate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Donate();
                return _instance;
            }
        }
        public Donate()
        {
            InitializeComponent();
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Donations.Instance))
            {
                panel1.Controls.Add(Donations.Instance);
                Donations.Instance.Dock = DockStyle.Fill;
                Donations.Instance.BringToFront();
            }
            else
                Donations.Instance.BringToFront();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Donors.Instance))
            {
                panel1.Controls.Add(Donors.Instance);
                Donors.Instance.Dock = DockStyle.Fill;
                Donors.Instance.BringToFront();
            }
            else
                Donors.Instance.BringToFront();
        }
    }
}
