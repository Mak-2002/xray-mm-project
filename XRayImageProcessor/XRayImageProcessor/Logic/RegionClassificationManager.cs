using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Logic
{
    public class RegionClassificationManager
    {
        public string ClassifyRegionCondition(Bitmap image, Rectangle region)
        {
            int whitePixelCount = 0;

            for (int y = region.Top; y < region.Bottom; y++)
            {
                for (int x = region.Left; x < region.Right; x++)
                {
                    if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
                        continue;

                    Color pixelColor = image.GetPixel(x, y);
                    int intensity = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    // Considering pixels with high intensity as "white" pixels
                    if (intensity > 100)
                    {
                        whitePixelCount++;
                    }
                }
            }

            int nonWhitePixelCount = region.Width * region.Height - whitePixelCount;
            double whitePortion = (double)whitePixelCount / int.Max(nonWhitePixelCount, 1);

            if (whitePortion > 2)
            {
                return "Sever Condition";
            }
            else if (whitePortion > 1)
            {
                return "Moderate Condition";
            }
            else
            {
                return "Mild Condition";
            }
        }
    }
}
