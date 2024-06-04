using AForge.Math.Geometry;
using NAudio.CoreAudioApi;
using NAudio.Utils;
using NAudio.Wave;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using XRayImageProcessor.Forms;
using XRayImageProcessor.Helpers;
using XRayImageProcessor.Logic;
using XRayImageProcessor.Shapes;

namespace XRayImageProcessor
{
    public partial class MainForm : Form
    {
        private ImageHandler imageHandler = new ImageHandler();
        private RegionManager regionManager = new RegionManager();
        private FilterManager filterManager = new FilterManager();
        private ImageHistory imageHistory = new ImageHistory();
        private RegionClassificationManager regionClassificationManager = new RegionClassificationManager();
        private FourierTransformationManager fourierTransformationManager = new FourierTransformationManager();
        private ShapeManager shapeManager = new ShapeManager();
        private AudioRecorder audioRecorder = new AudioRecorder();
        private ZipCompressor zipCompressor = new ZipCompressor();
        private PdfReportGenerator pdfReportGenerator = new PdfReportGenerator();
        private TelegramHelper telegramHelper = new TelegramHelper();
        private WaveInEvent? waveInEvent = new WaveInEvent();
        private WaveOutEvent? waveOutEvent = new WaveOutEvent();
        private WaveFileWriter? waveFileWriter;
        private MemoryStream audioStream = new();
        private bool isRecording = false;
        private bool isPlaying = false;

        private enum ShapeType { None, Rectangle, Triangle, Curve, Arrow }
        private ShapeType currentShapeType = ShapeType.None;

        //private byte[] audioData;
        private byte[] pdfReport;
        private byte[] zipFile;

        public MainForm()
        {
            InitializeComponent();
            InitializeFilters();
            cbShape.SelectedItem = "Rectangle";
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
            if (imageHandler.OriginalImage != null)
            {
                imageHistory.Clear();
                imageHistory.SaveState((Bitmap)pbXrayImage.Image.Clone());
            }
        }

        private void PbXrayImage_MouseDown(object sender, MouseEventArgs e)
        {
            regionManager.MouseDown(e.Location);
            switch (currentShapeType)
            {
                case ShapeType.Rectangle:
                    shapeManager.StartShape(new RectangleShape(), e.Location);
                    break;
                case ShapeType.Triangle:
                    shapeManager.StartShape(new TriangleShape(), e.Location);
                    break;
                case ShapeType.Curve:
                    shapeManager.StartShape(new CurveShape(), e.Location);
                    break;
                case ShapeType.Arrow:
                    shapeManager.StartShape(new ArrowShape(), e.Location);
                    break;
            }
        }

        private void PbXrayImage_MouseMove(object sender, MouseEventArgs e)
        {
            regionManager.MouseMove(e.Location, pbXrayImage);
            shapeManager.UpdateShape(e.Location);
            pbXrayImage.Invalidate();
        }

        private void PbXrayImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentShapeType == ShapeType.Rectangle)
            {
                regionManager.MouseUp(e.Location, pbXrayImage);
            }
            shapeManager.FinishShape();
            pbXrayImage.Invalidate();
            imageHistory.SaveState((Bitmap)pbXrayImage.Image);
        }

        private void PbXrayImage_Paint(object sender, PaintEventArgs e)
        {
            regionManager.DrawRegions(e);
            shapeManager.DrawShapes(e.Graphics); // Draw shapes
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

        private void BtnClassifyCondition_Click(object sender, EventArgs e)
        {
            if (imageHandler.OriginalImage == null || regionManager.SelectedRegions.Count == 0)
            {
                lblClassificationResult.Text = "Please load an image and select a region.";
                return;
            }

            // Use the last selected region for classification
            Rectangle selectedRegion = regionManager.SelectedRegions.Last();
            string classification = regionClassificationManager.ClassifyRegionCondition(
                imageHandler.OriginalImage,
                selectedRegion
            );
            lblClassificationResult.Text = classification;
        }

        private void compareDiseaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compareImagesForDiseaseProgressionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lowPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageHandler.OriginalImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            pbXrayImage.Image = fourierTransformationManager.applyLowPassFilterAndSharpen((Bitmap)pbXrayImage.Image);
            // Push an image to history
            imageHistory.SaveState((Bitmap)pbXrayImage.Image.Clone());
        }

        private void highPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageHandler.OriginalImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            pbXrayImage.Image = fourierTransformationManager.applyHighPassFilterAndSharpen((Bitmap)pbXrayImage.Image);
            // Push an image to history
            imageHistory.SaveState((Bitmap)pbXrayImage.Image.Clone());
        }
        private void BtnCropImage_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = imageHandler.OriginalImage;
            if (originalImage == null || regionManager.SelectedRegions.Count == 0)
            {
                MessageBox.Show("Please load an image and select a region to crop.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the last selected region
            Rectangle cropRegion = regionManager.SelectedRegions.Last();

            // Adjust the region for padding and scaling if necessary
            Rectangle adjustedRegion = regionManager.AdjustRegionForPaddingAndScaling(cropRegion, originalImage, pbXrayImage);

            // Crop the image to the selected region
            Bitmap croppedImage = imageHandler.CropImage(originalImage, adjustedRegion);

            // Update the picture box and original image with the cropped image
            pbXrayImage.Image = croppedImage;
            imageHandler.OriginalImage = croppedImage;

            // Clear the selected regions
            regionManager.SelectedRegions.Clear();
        }

        private void searchImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            searchForm.Show();
        }

        private void compare2ImagesForDiseaseProgressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareForm compareForm = new CompareForm();
            compareForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            compareForm.Show();
        }

        private void cbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbShape.SelectedItem.ToString())
            {
                case "Rectangle":
                    currentShapeType = ShapeType.Rectangle;
                    break;
                case "Triangle":
                    currentShapeType = ShapeType.Triangle;
                    break;
                case "Curve":
                    currentShapeType = ShapeType.Curve;
                    break;
                case "Arrow":
                    currentShapeType = ShapeType.Arrow;
                    break;
                default:
                    currentShapeType = ShapeType.None;
                    break;
            }
        }

        private void BtnAddTextNote_Click(object sender, EventArgs e)
        {
            if (imageHandler.OriginalImage == null)
            {
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your note:", "Add Text Note", "");
            if (!string.IsNullOrEmpty(input))
            {
                AddTextNoteToImage(imageHandler.OriginalImage, input);
            }
        }

        private void AddTextNoteToImage(Bitmap originalImage, string text)
        {
            Int32 fontSize = (Int32)((double)1 / 25 * Math.Min(originalImage.Width, originalImage.Height));
            Bitmap imageWithText = new Bitmap(originalImage);
            using (Graphics g = Graphics.FromImage(imageWithText))
            {
                Font font = new Font("Arial", fontSize, FontStyle.Regular);
                SolidBrush brush = new SolidBrush(Color.Red);
                PointF point = new PointF(10, 10);

                g.DrawString(text, font, brush, point);
            }

            pbXrayImage.Image = imageWithText;
            originalImage = imageWithText;
            imageHistory.SaveState(originalImage);
        }

        private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (waveFileWriter != null)
            {
                waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveFileWriter.Flush();
            }
        }

        private void OnRecordingStopped(object? sender, StoppedEventArgs e)
        {
            if (waveFileWriter != null)
            {
                waveFileWriter.Dispose();
                waveFileWriter = null;
            }

            if (waveInEvent != null)
            {
                waveInEvent.Dispose();
                waveInEvent = null;
            }
            if (waveOutEvent != null)
            {
                waveOutEvent.Dispose();
                waveOutEvent = null;
            }
        }

        private void btnAddVoiceNote_Click(object sender, EventArgs e)
        {
            isRecording = !isRecording;
            if (isRecording)
            {
                audioStream = new MemoryStream();
                waveInEvent = new WaveInEvent();
                waveInEvent.WaveFormat = new WaveFormat(44100, 1); // 44.1kHz mono
                waveInEvent.DataAvailable += OnDataAvailable;
                waveInEvent.RecordingStopped += OnRecordingStopped;

                waveFileWriter = new WaveFileWriter(new IgnoreDisposeStream(audioStream), waveInEvent.WaveFormat);
                waveInEvent.StartRecording();
            }
            else
            {
                waveInEvent?.StopRecording();
            }
        }

        private void generatePDFReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] imageData = null;
            try
            {
                imageData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", "output.png"));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please save the image first.");
                return;
            }

            var reportContent = new Dictionary<string, string> { };

            string caseName = Microsoft.VisualBasic.Interaction.InputBox("Please enter case name:", "Input Case Name", "");
            if (!string.IsNullOrEmpty(caseName))
            {
                reportContent.Add("Case Name", caseName);
            }

            string caseDescription = Microsoft.VisualBasic.Interaction.InputBox("Please enter case description:", "Input Case Description", "");
            if (!string.IsNullOrEmpty(caseDescription))
            {
                reportContent.Add("Case Description", caseDescription);
            }

            reportContent.Add("Date", DateTime.Now.ToString());
            //reportContent.Add("Image", imageData.ToString());


            pdfReport = pdfReportGenerator.GenerateReport(reportContent);
            File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", "Report.pdf"), pdfReport);
            MessageBox.Show("PDF Report Has Been Generated.", "PDF Report Generation");
        }

        private void exportAsZIPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] imageData = null;
            try
            {
                imageData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", "output.png"));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please save the image first.");
                return;
            }
            var zipData = zipCompressor.CompressToZip(imageData, pdfReport, audioStream);

            zipFile = zipData;

            File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", "compressedData.zip"), zipData);
            MessageBox.Show("Zip file generated and saved as 'compressedData.zip'.", "Compressed successfully");
        }

        private async void shareToTelegramBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            var botToken = "7187219845:AAEqNp-LtPrxuieFVFcNbvQkIDf8Zb0njAQ";
            var chatId = "1424639833";

            byte[] imageData = null;
            try
            {
                imageData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output", "output.png"));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please save the image first.");
                return;
            }

            bool somethingIsSent = false;
            try
            {
                await telegramHelper.ShareVoiceOnTelegram(botToken, chatId, audioStream.ToArray());
                somethingIsSent = true;
            }
            catch
            {

            }
            try
            {
                await telegramHelper.ShareImageOnTelegram(botToken, chatId, imageData);
                somethingIsSent = true;
            }
            catch
            {

            }
            try
            {
                await telegramHelper.ShareZIPtOnTelegram(botToken, chatId, zipFile);
                somethingIsSent = true;
            }
            catch
            {

            }
            if (somethingIsSent)
            {
                MessageBox.Show("Files sent to Telegram.", "Share on Telegram");
            }
            else
            {
                MessageBox.Show("Failed to share to Telegram.", "Share on Telegram");
            }
        }

        private void btnPlayVoiceNote_Click(object sender, EventArgs e)
        {
            if (waveOutEvent == null)
            {
                if (audioStream != null)
                {
                    InitAudio();
                }
            }
            else
            {
                if (waveOutEvent.PlaybackState == PlaybackState.Playing)
                {
                    waveOutEvent?.Pause();
                }
                else if (waveOutEvent.PlaybackState == PlaybackState.Paused)
                {
                    waveOutEvent.Play();
                }
                else if (waveOutEvent.PlaybackState == PlaybackState.Stopped)
                {
                    InitAudio();
                }
            }
        }

        private void InitAudio()
        {
            audioStream.Position = 0; // Reset stream position to the beginning
            var waveReader = new WaveFileReader(audioStream);
            waveOutEvent = new WaveOutEvent();
            waveOutEvent.Init(waveReader);
            waveOutEvent.Play();
        }
    }
}

