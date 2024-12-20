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
    public partial class FindStudents : Form
    {
        public FindStudents()
        {
            InitializeComponent();
        }

        private void FindStudents_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            string id = tbIdForSearch.Text.Trim(); // Get the ID from the input box

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter an ID.");
                return;
            }

            try
            {
                string query = "SELECT Image FROM tplPeople WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, coonString.dataCon))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    // Execute the query and get the image data as byte array
                    byte[] imageBytes = cmd.ExecuteScalar() as byte[];

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        // Convert byte array to Image and display it in the PictureBox
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            ImagesBox.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No image found for the specified ID.");
                 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
