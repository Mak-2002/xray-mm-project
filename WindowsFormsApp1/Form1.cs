using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string imagePath = "C:\\Users\\CoOoL\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\download.jpg";
            Bitmap image = new Bitmap(imagePath);
            // Save the image to a file
            string outputPath = "C:\\Users\\CoOoL\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\output.jpg";
            image.Save(outputPath);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp, *.gif)|*.jpg;*.png;*.bmp;*.gif|All Files (*.*)|*.*";
            openFileDialog.Title = "Select an Image File";

            // Display the OpenFileDialog and wait for the user's selection
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Load the selected image file
                string selectedFileName = openFileDialog.FileName;
                try
                {
                    Bitmap image = new Bitmap(selectedFileName);

                    // Process the image (you can add your code to deal with the image here)
                    // For example, you can display the image in a PictureBox, perform image processing, etc.

                    // Show a message to indicate that the image has been loaded
                    MessageBox.Show("Image loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Dispose of the image
                    image.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
