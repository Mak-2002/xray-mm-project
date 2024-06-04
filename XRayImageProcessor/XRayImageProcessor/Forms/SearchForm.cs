using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XRayImageProcessor.Forms
{
    public partial class SearchForm : Form
    {
        private List<ImageMetadata> imageMetadataList = new List<ImageMetadata>();
        private string defaultStorageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");

        public SearchForm()
        {
            InitializeComponent();
            LoadImageMetadata();
            InitializeListView();
        }

        private void LoadImageMetadata()
        {
            imageMetadataList.Clear();
            try
            {
                // Get all image files in the default storage location
                string[] imageFiles = Directory.GetFiles(defaultStorageLocation, "*.*", SearchOption.AllDirectories);
                foreach (string filePath in imageFiles)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string fileExtension = fileInfo.Extension.ToLower();
                    if (fileExtension == ".jpg" ||
                        fileExtension == ".jpeg" ||
                        fileExtension == ".png" ||
                        fileExtension == ".bmp")
                    {
                        imageMetadataList.Add(new ImageMetadata
                        {
                            FilePath = filePath,
                            FileSize = fileInfo.Length,
                            UpdateDate = fileInfo.LastWriteTime
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading image metadata: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeListView()
        {
            lvResults.Columns.Add("File Path", 200);
            lvResults.Columns.Add("File Size", 100);
            lvResults.Columns.Add("Update Date", 100);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lvResults.Items.Clear();

            long minSize = (long)nudMinSize.Value * 1024;
            long maxSize = (long)nudMaxSize.Value * 1024;
            DateTime minDate = dtpMinUpdateDate.Value.Date;
            DateTime maxDate = dtpMaxUpdateDate.Value.Date;

            foreach (var metadata in imageMetadataList)
            {
                if (metadata.FileSize >= minSize && metadata.FileSize <= maxSize && metadata.UpdateDate.Date >= minDate && metadata.UpdateDate.Date <= maxDate)
                {
                    ListViewItem item = new ListViewItem(metadata.FilePath);
                    item.SubItems.Add(FormatFileSize(metadata.FileSize));
                    item.SubItems.Add(metadata.UpdateDate.ToShortDateString());
                    lvResults.Items.Add(item);
                }
            }

            if (lvResults.Items.Count == 0)
            {
                lvResults.Items.Add(new ListViewItem("No images found."));
            }
        }

        private string FormatFileSize(long fileSize)
        {
            if (fileSize >= 1048576)
                return $"{fileSize / 1048576.0:F2} MB";
            if (fileSize >= 1024)
                return $"{fileSize / 1024.0:F2} KB";
            return $"{fileSize} B";
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class ImageMetadata
    {
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
