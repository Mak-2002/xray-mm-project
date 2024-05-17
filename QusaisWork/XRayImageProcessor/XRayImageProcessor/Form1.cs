using System.Windows.Forms;

namespace XRayImageProcessor
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private List<Rectangle> rectangles = new List<Rectangle>();
        private Point startPoint;
        private Rectangle currentRect;
        private bool isDrawing;
        private bool useBlueRedGreenMapping = true;
        private bool usePinkYellowOrange = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog.FileName);
                pictureBox.Image = image;
                rectangles.Clear();
                isDrawing = false;
                pictureBox.Invalidate();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap editedImage = new Bitmap(image);

                    using (Graphics g = Graphics.FromImage(editedImage))
                    {
                        foreach (Rectangle rect in rectangles)
                        {
                            FillRectangleWithGradient(g, rect);
                        }
                    }

                    editedImage.Save(saveFileDialog.FileName);
                    MessageBox.Show(
                        "Image saved successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void btnColor1_Click(object sender, EventArgs e)
        {
            useBlueRedGreenMapping = true;
            usePinkYellowOrange = false;
            MessageBox.Show(
                "Color mapping set to Blue-Red-Green based on brightness.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            usePinkYellowOrange = true;
            useBlueRedGreenMapping = false;
            MessageBox.Show(
                "Color mapping set to Pink-Yellow-Orange based on brightness.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (image != null)
            {
                startPoint = e.Location;
                isDrawing = true;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && image != null)
            {
                currentRect = new Rectangle(
                    Math.Min(startPoint.X, e.X),
                    Math.Min(startPoint.Y, e.Y),
                    Math.Abs(startPoint.X - e.X),
                    Math.Abs(startPoint.Y - e.Y)
                );
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left && currentRect.Width > 0 && currentRect.Height > 0)
            {
                rectangles.Add(currentRect);
                isDrawing = false;
                currentRect = Rectangle.Empty;
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (image != null)
            {
                foreach (Rectangle rect in rectangles)
                {
                    FillRectangleWithGradient(e.Graphics, rect);
                    e.Graphics.DrawRectangle(Pens.Red, rect);
                }

                if (isDrawing && currentRect != Rectangle.Empty)
                {
                    e.Graphics.DrawRectangle(Pens.Blue, currentRect);
                }
            }
        }

        private void FillRectangleWithGradient(Graphics g, Rectangle rect)
        {
            if (image == null) return;

            for (int x = rect.Left; x < rect.Right; x++)
            {
                for (int y = rect.Top; y < rect.Bottom; y++)
                {
                    if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                    {
                        Color pixelColor = image.GetPixel(x, y);

                        float brightness = pixelColor.GetBrightness();
                        Color gradientColor = GetColorBasedOnBrightness(brightness);

                        using (SolidBrush brush = new SolidBrush(gradientColor))
                        {
                            g.FillRectangle(brush, x, y, 1, 1);
                        }
                    }
                }
            }
        }

        private Color GetColorBasedOnBrightness(float brightness)
        {
            if (useBlueRedGreenMapping)
            {
                int red = (int)(brightness * 255);
                int blue = (int)((1 - brightness) * 255);
                return Color.FromArgb(255, blue, 0, red);
            }
            else if (usePinkYellowOrange)
            {
                if (brightness < 0.5)
                {
                    int yellowValue = (int)(brightness * 2 * 255);
                    return Color.FromArgb(255, 255, yellowValue, 255 - yellowValue);
                }
                else
                {
                    int orangeValue = (int)((brightness - 0.5) * 2 * 255);
                    return Color.FromArgb(255, 255, 255 - orangeValue, 0);
                }
            }
            else
            {
                int gray = (int)(brightness * 255);
                return Color.FromArgb(255, gray, gray, gray);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
