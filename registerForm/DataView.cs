using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registerForm
{
    public partial class DataView : Form
    {
        public DataView()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dbvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataView_Load(object sender, EventArgs e)
        {
            try
            {
                // Ensure there is an Image column in dbvStudent
                if (!dbvStudent.Columns.Contains("Image"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.Name = "Image";
                    imgCol.HeaderText = "Profile Image";
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // Set to Zoom to fit the image within the cell
                    dbvStudent.Columns.Add(imgCol);

                }

                string sql = "SELECT * FROM tplPeople";
                SqlCommand s = new SqlCommand(sql, coonString.dataCon);
                SqlDataReader r = s.ExecuteReader();

                while (r.Read())
                {
                    string id = r.GetValue(0).ToString();
                    string name = r.GetValue(1).ToString();
                    string address = r.GetValue(2).ToString();
                    string age = r.GetValue(3).ToString();
                    byte[] imageBytes = r["Image"] as byte[];

                    // Convert byte array to Image
                    Image image = null;
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            image = Image.FromStream(ms);
                        }
                    }

                    // Add row with image to DataGridView
                    dbvStudent.Rows.Add(id, name, address, age, image);
                }

                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
           try
            {

                new RegisterForm().Show();
                this.Dispose();
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                new FindStudents().Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
