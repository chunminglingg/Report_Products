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
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void btnViewPeople_Click(object sender, EventArgs e)
        {
   
            new  DataView().Show();
            this.Dispose();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new InsertNewProducts().Show();
            this.Dispose();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void lbInsertData_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Click(object sender, EventArgs e)
        {
            new Sales().Show();
            this.Dispose();
        }
    }
}
