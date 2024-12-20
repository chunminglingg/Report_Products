using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registerForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void cbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbAuth.SelectedIndex;
            if (index == 0)
            {
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            try
            {
                string ip = "MINGG\\MINGSERVER";
                string dbName = "SRPro";
                string user = txtUser.Text;
                string password = txtPassword.Text;
                int index = cbAuth.SelectedIndex;

                if (index == 0)
                {
                    coonString.connectionDb(ip, dbName);
                }
                else
                {
                    coonString.connectionDb(ip, dbName, user, password);
                }

                // display the form if the connection is true         
                new LandingPage().Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
