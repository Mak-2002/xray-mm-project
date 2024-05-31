using System.Drawing;
using System.Windows.Forms;

namespace XRayImageProcessor
{
    public class ImageHandler
    {
        public Bitmap OriginalImage { get; private set; }

        public void LoadImage(PictureBox pictureBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    OriginalImage = new Bitmap(ofd.FileName);
                    pictureBox.Image = new Bitmap(OriginalImage);
                }
            }
        }

        public void SaveImage(PictureBox pictureBox)
        {
            if (pictureBox.Image == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image.Save(sfd.FileName);
                }
            }
        }
    }
}