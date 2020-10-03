using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Social_app
{
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
            label2.Text = Form1.name;
        }

        private void Manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }             
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dlg = new Form1();
            dlg.Show();
            dlg.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(Donate.Instance))
            {
                panel2.Controls.Add(Donate.Instance);
                Donate.Instance.Dock = DockStyle.Fill;
                Donate.Instance.BringToFront();
            }
            else
                Donate.Instance.BringToFront();
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void BunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
