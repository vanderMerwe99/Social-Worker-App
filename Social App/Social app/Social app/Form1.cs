using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Social_app
{
    public partial class Form1 : Form
    {
        public static string role = "";
        public static string name = "";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\brand\OneDrive\Desktop\Year 2\CMPG 223\Social app\Social app\Info.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            panel2.BackColor = Color.FromArgb(75, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users WHERE Employee_ID = '" +textBox1.Text.Trim() +"' AND Password = '" + textBox2.Text.Trim() + "'" ,con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Employee_ID = '" + textBox1.Text.Trim() + "' AND Password = '" + textBox2.Text.Trim() + "'", con);
            SqlDataReader dr;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        role = dr.GetValue(4).ToString().Trim();
                        name = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString();
                        if (role == "Manage")
                        {
                            this.Hide();
                            Manage dlg1 = new Manage();
                            dlg1.Show();
                            dlg1.BringToFront();
                        }
                        else if (role == "Social")
                        {
                            this.Hide();
                            Social dlg = new Social();
                            dlg.Show();
                            dlg.BringToFront();
                        }
                    }
                }
                else
                    MessageBox.Show("Please make sure you have entered the correct information","Invalid Details",MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            catch(Exception er)
            {
                MessageBox.Show("Error!!",""+er);
            }
        }
    }
}
