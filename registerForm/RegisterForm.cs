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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // store value from txtBox
            string name = tbName.Text;
            string age = txtAge.Text;
            string address = txtAddress.Text;

            try
            {
                // Insert query including the image
                string insertQuery = "INSERT INTO tplPeople (Name, Address, Age, Image) VALUES (@Name, @Address, @Age, @Image);";
                SqlCommand cmd = new SqlCommand(insertQuery, coonString.dataCon);

                // Add parameters to the command
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Age", age);

                // Get the image from PictureBox and convert it to a byte array
                byte[] imageBytes = ImageToByteArray(pictureBox1.Image);
                cmd.Parameters.AddWithValue("@Image", (object)imageBytes ?? DBNull.Value); // Store as DBNull if no image



                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the query
                if (rowsAffected > 0)
                {
                    // Show confirmation dialog
                    DialogResult dialogResult = MessageBox.Show("Person inserted successfully. Do you want to view the data?", "Confirmation", MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        // Hide the current form
                        this.Hide();

                        // Show the DataView form
                        DataView dataView = new DataView();
                        dataView.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to insert the person.");
                }

                cmd.Dispose();

            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Save the image to the memory stream in PNG format
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray(); // Return the image as a byte array
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFile.FileName);
            }
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
