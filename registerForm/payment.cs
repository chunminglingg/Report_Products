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
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        public payment(double totalamount)
        {
            InitializeComponent();
            TotalAmount = totalamount;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Dispose();
        }

        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountPrice { get; set; }
        
        public double Pay { get; set; }
        public double CashReceived { get; set; }
        public double CashReturn { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string dis = comboBox1.SelectedItem.ToString().TrimEnd('%');
                if (double.TryParse(dis, out double discount))
                {
                    Discount = discount;
                    DiscountPrice = TotalAmount * Discount / 100;
                    Pay = TotalAmount - DiscountPrice;

                    txtDis.Text = DiscountPrice.ToString("$#,##0.00");
                    txtPay.Text = TotalAmount.ToString("$#,##0.00");
                }
                else
                {
                    MessageBox.Show("Invalid discount value.");
                }
            }

        }

        private void payment_Load(object sender, EventArgs e)
        {
           

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            txtTotalAmount.Text = TotalAmount.ToString("$#,##0.00");
        }

        private void txtCashReceive_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter)
            {
                try
                {
                    string recieved = txtCashReceive.Text.Trim();
                    CashReceived = double.Parse(recieved);
                    if(CashReceived >= Pay)
                    {
                        CashReturn = CashReceived - Pay;
                        txtCashReturn.Text = CashReturn.ToString("$#,##0.00");
                        pay.Enabled = true;
                    }
                    else
                    {
                        txtCashReturn.Text = "$0.00";
                        pay.Enabled = false;
                    }
                } catch(Exception ex) 
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
