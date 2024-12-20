using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registerForm
{
    public partial class InsertNewProducts : Form
    {
        public InsertNewProducts()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private List<string> cid = new List<string>();
        private List<string> cname = new List<string>();

        private void InsertNewProducts_Load(object sender, EventArgs e)
        {
            ShowData();
            try
            {
                string sql = "select * from tblCategory";
                SqlCommand cmd = new SqlCommand(sql,coonString.dataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string catID = reader[0].ToString();
                    string catName = reader[1].ToString();
                    comboBox1.Items.Add(catName);
                    cid.Add(catID);
                    cname.Add(catName);
                    comboBox1.SelectedIndex = 0;
                }
                reader.Close();
                cmd.Dispose();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowData()
        {
            try
            {
                dvgProduct.Rows.Clear();
                string sql = "select * from tblProduct";
                SqlCommand s = new SqlCommand(sql, coonString.dataCon);
                SqlDataReader r = s.ExecuteReader();

                while (r.Read())
                {
                    string pid = r.GetValue(0) + "";
                    string Pname = r[1] + "";
                    string price = r[2] + "";
                    string qty = r[3] + "";
                    string cid = r[4] + "";
                    string barcode = r[5] + "";
                    dvgProduct.Rows.Add(pid, Pname, qty, price, cid, barcode);
                }
                r.Close();
                //DataConnection.dataCon.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // store value of txtBox and combo on the form 
            string barcode = txtBarcode.Text;
            string pname = txtPname.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;
            string catID = txtCatID.Text;

           try
            {
                string insertQuery = "INSERT INTO tblProduct (Barcode, PName, Qty, Price, CatID) VALUES (@Barcode, @PName, @Qty, @Price, @CatID)";
                SqlCommand cmd = new SqlCommand(insertQuery, coonString.dataCon);

                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.Parameters.AddWithValue("@PName", pname);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.Parameters.AddWithValue("@Price",price);
                cmd.Parameters.AddWithValue("@CatID", catID);

                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the query
                if (rowsAffected > 0)
                {
                    // Show confirmation dialog
                    DialogResult dialogResult = MessageBox.Show("Products inserted successfully. Do you want to continue?", "Confirmation", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
             
                        InsertNewProducts_Load(sender, e);
                        txtBarcode.Text = "";
                        txtPname.Text = "";
                        txtPrice.Text = "";
                        txtQty.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Failed to insert the person.");
                }
                cmd.Dispose();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = comboBox1.SelectedIndex;
                txtCatID.Text = cid[index];
            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dvgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
        }

        int idForUpdate;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(dvgProduct.SelectedRows.Count > 0)
                {
                    int row = dvgProduct.SelectedRows[0].Index;
                    int id = int.Parse(dvgProduct.Rows[row].Cells[0].Value.ToString());
                    idForUpdate = id;
                    string sql = "delete from tblProduct where PID="+id+";";
                    SqlCommand s = new SqlCommand(sql,coonString.dataCon);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    ShowData();
                    MessageBox.Show("Data Deleted Successfully!");
                }
            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dvgProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgProduct.CurrentRow != null)
            {
                int row = dvgProduct.CurrentRow.Index;
                int pid = int.Parse(dvgProduct.Rows[row].Cells[0].Value.ToString());
                string pname = dvgProduct.Rows[row].Cells[1].Value.ToString();
                int price = int.Parse(dvgProduct.Rows[row].Cells[2].Value.ToString());
                int qty = int.Parse(dvgProduct.Rows[row].Cells[3].Value.ToString());
                int catID = int.Parse(dvgProduct.Rows[row].Cells[4].Value.ToString());
                string barcode = dvgProduct.Rows[row].Cells[5].Value.ToString();

                txtBarcode.Text = barcode;
                txtPname.Text = pname;
                txtPrice.Text = price.ToString();
                txtQty.Text = qty.ToString();
                txtCatID.Text = catID.ToString();

                string testCatId = catID + "";
                int ind = 0;
                for (int i = 0; i < cid.Count; i++)
                {
                    if (cid[i] == testCatId)
                    {
                        ind = i; break; 
                    }
                }

                comboBox1.SelectedItem = cname[ind];
            }
        }

        private void clear()
        {
            txtBarcode.Text = "";
            txtPname.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Collect values from TextBox controls
            string barcode = txtBarcode.Text;
            string pname = txtPname.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;
            string catID = txtCatID.Text;

            string sql = "UPDATE tblProduct SET PName = '"+pname+"', Price = " + price +", Qty = "+qty+", CatID = "+catID+" WHERE Barcode = "+barcode+"";
            SqlCommand s = new SqlCommand(sql, coonString.dataCon);
            s.ExecuteNonQuery();
            s.Dispose();
   
            
            ShowData();
            clear();
            MessageBox.Show("Data updated successfully!");

        }
    }
}
