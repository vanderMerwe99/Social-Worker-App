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

namespace Social_app
{
    public partial class Delete : Form
    {
        int ID;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\brand\OneDrive\Desktop\Year 2\CMPG 223\Social app\Social app\Info.mdf;Integrated Security=True");
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Donors",con);
            SqlDataReader dr;

            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!textBox1.AutoCompleteCustomSource.Contains(dr.GetString(1)))
                    {
                        textBox1.AutoCompleteCustomSource.Add(dr.GetString(1) + " " + dr.GetString(2));
                    }
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
                con.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Donors WHERE Donor_ID = '"+ID+"'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Donor deleted");
                this.Close();
            }
            catch(Exception er)
            {
                MessageBox.Show("" + er);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] token = textBox1.Text.Split(' ');
            string first = token[0];
            SqlCommand cmd = new SqlCommand("SELECT * FROM Donors WHERE First_Name = '"+ first +"'", con);
            SqlDataReader dr;

            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ID = dr.GetInt32(0);
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
                con.Close();
            }
        }
    }
}
