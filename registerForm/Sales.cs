using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace registerForm
{
    public partial class Sales : Form
    {

        public Sales()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void qty_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        List<OrderDetails> order = new List<OrderDetails>();

        private bool orderProduct(int pid)
        {
            string sql = "SELECT * FROM tblProduct WHERE PID = @PID";
            using (SqlCommand cmd = new SqlCommand(sql, coonString.dataCon))
            {
                cmd.Parameters.AddWithValue("@PID", pid);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string pname = reader["Pname"].ToString(); // Replace with actual column name
                        double price = double.Parse(reader["Price"].ToString()); // Replace with actual column name
                        int qty = string.IsNullOrWhiteSpace(txtQty.Text) ? 1 : int.Parse(txtQty.Text.Trim());
                        double amount = qty * price;

                        // Add the product to the DataGridView
                        int no = data.Rows.Count + 1;
                        data.Rows.Add(no, pname, price.ToString("$0.00"), qty, amount.ToString("$#,##0.00"));
                        OrderDetails obj = new OrderDetails(qty,pid);
                        order.Add(obj);

                        return true;
                    }
                }
            }
            return false;
        }

        private double TotalAmount()
        {
            double total = 0;

            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.IsNewRow) continue;

                var amountCell = row.Cells[4].Value; // Amount column index
                if (amountCell != null && double.TryParse(amountCell.ToString().Trim('$'), out double amount))
                {
                    total += amount;
                }
            }

            return total;
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtPid.Text.Trim(), out int pid))
                {
                    if (orderProduct(pid))
                    {
                        txtQty.Clear();
                        txtPid.Clear();
                        txtTotal.Text = TotalAmount().ToString("$#,##0.00");
                    }
                    else
                    {
                        MessageBox.Show("Product not in stock.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Product ID. Please enter a valid number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private int InsertOrder (double discount, double pay)
        {
            string ODate = DateTime.Now.ToString("yyyy-MM-dd");
            string OTime = DateTime.Now.ToString("HH:mm:ss");
            string seller = coonString.Seller;
            double total = pay;
            double dis = discount;

            string query = $"INSERT INTO tblOrder (OrdDate, OrdTime, Discount, Total, SellerName) " +
                           $"VALUES ('{ODate}', '{OTime}', {dis}, {total}, '{seller}')";
            SqlCommand s = new SqlCommand(query, coonString.dataCon);
            s.ExecuteNonQuery();
            int oId = 0;
            query = "SELECT SCOPE_IDENTITY()";
            s = new SqlCommand (query, coonString.dataCon);
            SqlDataReader r = s.ExecuteReader();
            if (r.Read())
            {
                oId = int.Parse(r[0] + "");
                MessageBox.Show("Order inserted successfully.");
                r.Close();

            }
            s.Dispose();
            return oId;

        }

        private void InsertOrderDetail(int OrId)
        {
            foreach(OrderDetails temp in order)
            {
                int pid = temp.PID;
                int qty = temp.Qty;
                string query = $"INSERT INTO tblOrderDetails (OrdID, PID, Qty) VALUES ('{OrId}', '{pid}', '{qty}');";

                SqlCommand s = new SqlCommand(query, coonString.dataCon);
                s.ExecuteNonQuery();
                s.Dispose();
            }
        }

        private void UpdateStock()
        {
            foreach (OrderDetails temp in order)
            {
                int pid = temp.PID;
                int qty = temp.Qty;
                string query = $"UPDATE tblProduct SET Qty = Qty - {qty} WHERE PID={pid}";
                SqlCommand s = new SqlCommand(query , coonString.dataCon);
                s.ExecuteNonQuery();
                s.Dispose();
            }
        }

        private void Payment_Click(object sender, EventArgs e)
        {

  
            payment frmPay = new payment(TotalAmount());


            if(frmPay.ShowDialog() == DialogResult.OK)
            {
                // insert data to tplOrder
                int OrId = InsertOrder(frmPay.Discount, frmPay.Pay);

                //Insert data to tblOrderDetails
                InsertOrderDetail(OrId);

                // Update stock
                UpdateStock();

                //Clear previous data in datagrid
                order = new List<OrderDetails>();
                data.Rows.Clear();
                txtTotal.Clear();

            }
        }
    }
}
