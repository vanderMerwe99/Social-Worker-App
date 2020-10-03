using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Social_app
{
    public partial class CurrentDonors : UserControl
    {
        private static CurrentDonors _instance;

        public static CurrentDonors Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentDonors();
                return _instance;
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\brand\OneDrive\Desktop\Year 2\CMPG 223\Social app\Social app\Info.mdf;Integrated Security=True");
        public CurrentDonors()
        {
            InitializeComponent();
;
        }

        public void load()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Donors",con);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                sda.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
                con.Close();
            }
        }

        public void CurrentDonors_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
