using System;
using System.Drawing;
using System.Windows.Forms;
using XRayImageProcessor.Logic;

namespace XRayImageProcessor
{
    public partial class MainForm : Form
    {
        private ImageHandler imageHandler = new ImageHandler();
        private RegionManager regionManager = new RegionManager();
        private FilterManager filterManager = new FilterManager();
        private ImageHistory imageHistory = new ImageHistory(); // Image history manager

        public MainForm()
        {
            InitializeComponent();
            InitializeFilters();
        }

        private void InitializeFilters()
        {
            cbFilters.Items.AddRange(filterManager.GetFilterNames());
            cbFilters.SelectedIndex = 0;
            filterManager.SetCurrentFilter(cbFilters.SelectedItem.ToString());
        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            imageHandler.LoadImage(pbXrayImage);
            imageHistory.Clear();
            imageHistory.SaveState((Bitmap)pbXrayImage.Image.Clone());
        }

        private void PbXrayImage_MouseDown(object sender, MouseEventArgs e)
        {
            regionManager.MouseDown(e.Location);
        }

        private void PbXrayImage_MouseMove(object sender, MouseEventArgs e)
        {
            regionManager.MouseMove(e.Location, pbXrayImage);
        }

        private void PbXrayImage_MouseUp(object sender, MouseEventArgs e)
        {
            regionManager.MouseUp(e.Location, pbXrayImage);
        }

        private void PbXrayImage_Paint(object sender, PaintEventArgs e)
        {
            regionManager.DrawRegions(e);
        }

        private void BtnSelectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    filterManager.SetCustomFilterColor(colorDialog.Color);
                }
            }
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            if (pbXrayImage.Image == null || regionManager.SelectedRegions.Count == 0) return;

            filterManager.SetCurrentFilter(cbFilters.SelectedItem.ToString());

            Bitmap displayedImage = (Bitmap)pbXrayImage.Image;
            using (Graphics g = Graphics.FromImage(displayedImage))
            {
                Rectangle lastRegion = regionManager.SelectedRegions.Last();
                Rectangle adjustedRegion = regionManager.AdjustRegionForPaddingAndScaling(lastRegion, imageHandler.OriginalImage, pbXrayImage);
                filterManager.ApplyFilterToRegion(displayedImage, adjustedRegion);
            }

            pbXrayImage.Image = displayedImage;

            // Push an image to history
            imageHistory.SaveState((Bitmap)pbXrayImage.Image.Clone());
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            imageHandler.SaveImage(pbXrayImage);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            Bitmap? previousImage = imageHistory.Undo();
            if (previousImage != null)
            {
                pbXrayImage.Image = previousImage;
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterManager.SetCurrentFilter(cbFilters.SelectedItem.ToString());

            if (cbFilters.SelectedItem.ToString() == "Custom Color")
            {
                btnSelectColor.Visible = true;
            }
            else
            {
                btnSelectColor.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnOpenCompareForm_Click(object sender, EventArgs e)
        {
            CompareForm compareForm = new CompareForm();
            compareForm.Show();
        }
    }
}
