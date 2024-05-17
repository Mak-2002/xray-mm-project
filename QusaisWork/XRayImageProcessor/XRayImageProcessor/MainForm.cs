using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XRayImageProcessor.Filters;

namespace XRayImageProcessor
{
    public partial class MainForm : Form
    {
        private Point startPoint;
        private List<Rectangle> selectedRegions = new List<Rectangle>();
        private List<Color> regionColors = new List<Color>();
        private Bitmap originalImage;
        private Dictionary<string, IFilter> filters = new Dictionary<string, IFilter>();
        private IFilter currentFilter;

        public MainForm()
        {
            InitializeComponent();
            InitializeFilters();
        }

        private void InitializeFilters()
        {
            filters.Add("Tumor Progression", new TumorProgressionFilter());
            filters.Add("Grayscale", new GrayscaleFilter());

            cbFilters.Items.AddRange(filters.Keys.ToArray());
            cbFilters.SelectedIndex = 0;
            currentFilter = filters[cbFilters.SelectedItem.ToString()];
        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(ofd.FileName);
                    pbXrayImage.Image = new Bitmap(originalImage);
                    selectedRegions.Clear();
                    regionColors.Clear();
                }
            }
        }

        private void PbXrayImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (pbXrayImage.Image == null) return;
            startPoint = e.Location;
        }

        private void PbXrayImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (pbXrayImage.Image == null || e.Button != MouseButtons.Left) return;
            Rectangle currentRegion = new Rectangle(
                Math.Min(startPoint.X, e.X),
                Math.Min(startPoint.Y, e.Y),
                Math.Abs(startPoint.X - e.X),
                Math.Abs(startPoint.Y - e.Y));
            pbXrayImage.Invalidate();
        }

        private void PbXrayImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (pbXrayImage.Image == null) return;
            Rectangle currentRegion = new Rectangle(
                Math.Min(startPoint.X, e.X),
                Math.Min(startPoint.Y, e.Y),
                Math.Abs(startPoint.X - e.X),
                Math.Abs(startPoint.Y - e.Y));
            selectedRegions.Add(currentRegion);
            regionColors.Add(Color.Empty);
            pbXrayImage.Invalidate();
        }

        private void PbXrayImage_Paint(object sender, PaintEventArgs e)
        {
            if (pbXrayImage.Image == null) return;
            for (int i = 0; i < selectedRegions.Count; i++)
            {
                using (Pen pen = new Pen(regionColors[i] == Color.Empty ? Color.Red : regionColors[i], 2))
                {
                    e.Graphics.DrawRectangle(pen, selectedRegions[i]);
                }
            }
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            if (pbXrayImage.Image == null || selectedRegions.Count == 0) return;

            currentFilter = filters[cbFilters.SelectedItem.ToString()];

            // Work directly on the displayed image
            Bitmap displayedImage = (Bitmap)pbXrayImage.Image;



            using (Graphics g = Graphics.FromImage(displayedImage))
            {
                // Apply the filter to the last selected region only
                Rectangle lastRegion = selectedRegions.Last();
                Rectangle adjustedRegion = AdjustRegionForPaddingAndScaling(lastRegion);
                ApplyFilterToRegion(displayedImage, adjustedRegion);
            }

            pbXrayImage.Image = displayedImage;
        }

        private Rectangle AdjustRegionForPaddingAndScaling(Rectangle region)
        {
            // Calculate the scaling factors and aspect ratios
            float imageAspect = (float)originalImage.Width / originalImage.Height;
            float boxAspect = (float)pbXrayImage.Width / pbXrayImage.Height;

            int boxWidth = pbXrayImage.Width;
            int boxHeight = pbXrayImage.Height;
            int imageWidth, imageHeight;
            int offsetX = 0, offsetY = 0;

            if (imageAspect > boxAspect)
            {
                imageWidth = boxWidth;
                imageHeight = (int)(boxWidth / imageAspect);
                offsetY = (boxHeight - imageHeight) / 2;
            }
            else
            {
                imageHeight = boxHeight;
                imageWidth = (int)(boxHeight * imageAspect);
                offsetX = (boxWidth - imageWidth) / 2;
            }

            // Calculate the scaling factors based on the adjusted display area
            float scaleX = (float)originalImage.Width / imageWidth;
            float scaleY = (float)originalImage.Height / imageHeight;

            // Adjust the region coordinates to match the original image scale
            int x = (int)((region.X - offsetX) * scaleX);
            int y = (int)((region.Y - offsetY) * scaleY);
            int width = (int)(region.Width * scaleX);
            int height = (int)(region.Height * scaleY);

            return new Rectangle(x, y, width, height);
        }

        private void ApplyFilterToRegion(Bitmap bmp, Rectangle region)
        {
            // Apply the filter to each pixel in the region
            for (int x = region.Left; x < region.Right; x++)
            {
                for (int y = region.Top; y < region.Bottom; y++)
                {
                    if (x >= 0 && y >= 0 && x < bmp.Width && y < bmp.Height)
                    {
                        Color originalColor = bmp.GetPixel(x, y);
                        int intensity = (int)((originalColor.R + originalColor.G + originalColor.B) / 3.0);
                        Color newColor = currentFilter.ApplyFilter(intensity);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            if (pbXrayImage.Image == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp"; // Set filter for saving images
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pbXrayImage.Image.Save(sfd.FileName); // Save the modified image
                }
            }
        }
    }
}
