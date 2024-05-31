using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace XRayImageProcessor
{
    public partial class CompareForm : Form
    {
        private Bitmap imageA;
        private Bitmap imageB;

        public CompareForm()
        {
            InitializeComponent();
        }

        private void BtnLoadImageA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageA = new Bitmap(ofd.FileName);
                    pbXrayImageA.Image = new Bitmap(imageA);
                }
            }
        }

        private void BtnLoadImageB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageB = new Bitmap(ofd.FileName);
                    pbXrayImageB.Image = new Bitmap(imageB);
                }
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            if (imageA == null || imageB == null)
            {
                lblComparisonResult.Text = "Please load both images.";
                return;
            }

            // Simple comparison logic: compare the images pixel by pixel and check if there are significant differences
            bool significantChange = CompareImages(imageA, imageB);

            lblComparisonResult.Text = significantChange
                ? "Significant change detected."
                : "No significant change detected.";
        }

        private bool CompareImages(Bitmap imgA, Bitmap imgB)
        {
            if (imgA.Width != imgB.Width || imgA.Height != imgB.Height)
            {
                return true; // Different sizes indicate significant change
            }

            int diffCount = 0;
            int totalPixels = imgA.Width * imgA.Height;

            for (int y = 0; y < imgA.Height; y++)
            {
                for (int x = 0; x < imgA.Width; x++)
                {
                    Color colorA = imgA.GetPixel(x, y);
                    Color colorB = imgB.GetPixel(x, y);

                    if (colorA != colorB)
                    {
                        diffCount++;
                    }
                }
            }

            // Define a threshold for what constitutes a "significant" change
            double diffPercentage = (double)diffCount / totalPixels;
            return diffPercentage > 0.05; // 5% difference threshold
        }

        private void pbXrayImageA_Click(object sender, EventArgs e)
        {

        }
    }
}
