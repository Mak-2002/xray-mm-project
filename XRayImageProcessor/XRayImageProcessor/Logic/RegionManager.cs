using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XRayImageProcessor
{
    public class RegionManager
    {
        private Point startPoint;
        public List<Rectangle> SelectedRegions { get; private set; } = new List<Rectangle>();
        public List<Color> RegionColors { get; private set; } = new List<Color>();

        public void MouseDown(Point location)
        {
            startPoint = location;
        }

        public void MouseMove(Point location, PictureBox pictureBox)
        {
            if (pictureBox.Image == null) return;
            Rectangle currentRegion = new Rectangle(
                Math.Min(startPoint.X, location.X),
                Math.Min(startPoint.Y, location.Y),
                Math.Abs(startPoint.X - location.X),
                Math.Abs(startPoint.Y - location.Y));
            pictureBox.Invalidate();
        }

        public void MouseUp(Point location, PictureBox pictureBox)
        {
            if (pictureBox.Image == null) return;
            Rectangle currentRegion = new Rectangle(
                Math.Min(startPoint.X, location.X),
                Math.Min(startPoint.Y, location.Y),
                Math.Abs(startPoint.X - location.X),
                Math.Abs(startPoint.Y - location.Y));
            SelectedRegions.Add(currentRegion);
            RegionColors.Add(Color.Empty);
            pictureBox.Invalidate();
        }

        public void DrawRegions(PaintEventArgs e)
        {
            for (int i = 0; i < SelectedRegions.Count; i++)
            {
                Color borderColor = (i == SelectedRegions.Count - 1) ? Color.Red : RegionColors[i];
                using (Pen pen = new Pen(borderColor, 2))
                {
                    e.Graphics.DrawRectangle(pen, SelectedRegions[i]);
                }
            }
        }

        public Rectangle AdjustRegionForPaddingAndScaling(Rectangle region, Bitmap originalImage, PictureBox pictureBox)
        {
            float imageAspect = (float)originalImage.Width / originalImage.Height;
            float boxAspect = (float)pictureBox.Width / pictureBox.Height;

            int boxWidth = pictureBox.Width;
            int boxHeight = pictureBox.Height;
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

            float scaleX = (float)originalImage.Width / imageWidth;
            float scaleY = (float)originalImage.Height / imageHeight;

            int x = (int)((region.X - offsetX) * scaleX);
            int y = (int)((region.Y - offsetY) * scaleY);
            int width = (int)(region.Width * scaleX);
            int height = (int)(region.Height * scaleY);

            return new Rectangle(x, y, width, height);
        }
    }
}
