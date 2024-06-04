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
                ? "Significant change detected (progress in treatment or disease deterioration)."
                : "No significant change detected.";
        }

        private bool CompareImages(Bitmap imgA, Bitmap imgB)
        {
            // Resize imgB to match the dimensions of imgA if they are different
            if (imgA.Width != imgB.Width || imgA.Height != imgB.Height)
            {
                imgB = new Bitmap(imgB, imgA.Width, imgA.Height);
            }

            // Normalize images to reduce the effect of lighting differences
            Bitmap normalizedImgA = NormalizeImage(imgA);
            Bitmap normalizedImgB = NormalizeImage(imgB);

            int diffCount = 0;
            int totalPixels = normalizedImgA.Width * normalizedImgA.Height;

            for (int y = 0; y < normalizedImgA.Height; y++)
            {
                for (int x = 0; x < normalizedImgA.Width; x++)
                {
                    Color colorA = normalizedImgA.GetPixel(x, y);
                    Color colorB = normalizedImgB.GetPixel(x, y);

                    if (!ColorsAreSimilar(colorA, colorB))
                    {
                        diffCount++;
                    }
                }
            }

            // Define a threshold for what constitutes a "significant" change
            double diffPercentage = (double)diffCount / totalPixels;
            return diffPercentage > 0.05; // 5% difference threshold
        }

        private Bitmap NormalizeImage(Bitmap image)
        {
            // Simple normalization: convert to grayscale to minimize color variation effects
            Bitmap normalizedImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j);
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    normalizedImage.SetPixel(i, j, grayColor);
                }
            }

            return normalizedImage;
        }

        private bool ColorsAreSimilar(Color colorA, Color colorB)
        {
            // Simple similarity check based on a threshold in grayscale intensity
            int threshold = 15; // Intensity difference threshold
            int colorADiff = Math.Abs(colorA.R - colorB.R);
            int colorBDiff = Math.Abs(colorA.G - colorB.G);
            int colorCDiff = Math.Abs(colorA.B - colorB.B);

            return (colorADiff < threshold && colorBDiff < threshold && colorCDiff < threshold);
        }

        private void pbXrayImageA_Click(object sender, EventArgs e)
        {

        }
    }
}
