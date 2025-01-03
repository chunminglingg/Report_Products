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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        public void setSource(List<ReportDetails>arr)
        {
            CrystalReport11.SetDataSource(arr);
        }

        public void Print(int n, bool col, int start, int end)
        {
            CrystalReport11.PrintToPrinter(n, col, start, end);
        }

        public void setParameter(int index, object value)
        {
            CrystalReport11.SetParameterValue(index, value);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
