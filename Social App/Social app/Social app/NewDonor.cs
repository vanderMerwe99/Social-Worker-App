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
using System.IO;

namespace Social_app
{
    public partial class NewDonor : UserControl
    {
        private static NewDonor _instance;
        string img = "";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\brand\OneDrive\Desktop\Year 2\CMPG 223\Social app\Social app\Info.mdf;Integrated Security=True");
        public static NewDonor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NewDonor();
                return _instance;
            }
        }
        public NewDonor()
        {
            InitializeComponent();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            pictureBox1.Image = Properties.Resources.male_user;

        }
        void insert()
        {
            byte[] imageBT = null;
            FileStream fStream = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageBT = br.ReadBytes((int)fStream.Length);

            string query = "INSERT INTO Donors (First_Name,Last_Name,Phone_Number, Email_Address,Picture,Organization) VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "', @IMG , '"+textBox5.Text.Trim()+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myReader;

            try
            {
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@IMG", imageBT));
                myReader = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Donor has been saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
                con.Close();
            }
        }

        void loadPic()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dlg.FileName;
                img = picLoc;
                pictureBox1.ImageLocation = picLoc;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            insert();
            CurrentDonors dlg = new CurrentDonors();
            dlg.load();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            loadPic();
        }
    }
}
