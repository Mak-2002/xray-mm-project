using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    internal class TumorProgressionFilter : IFilter
    {
        public Color ApplyFilter(Color originalColor)
        {
            int intensity = (int)((originalColor.R + originalColor.G + originalColor.B) / 3.0);

            Color newColor;

            Color lowColor = Color.Red;         
            Color midColor = Color.Blue;
            Color highColor = Color.Green;

            if (intensity < 85)
            {
                float t = intensity / 85f;
                newColor = InterpolateColor(lowColor, midColor, t);
            }
            else if (intensity < 170)
            {
                float t = (intensity - 85) / 85f;
                newColor = InterpolateColor(midColor, highColor, t);
            }
            else
            {
                newColor = highColor;
            }

            int blendedR = (int)((originalColor.R * 0.7) + (newColor.R * 0.3));
            int blendedG = (int)((originalColor.G * 0.7) + (newColor.G * 0.3));
            int blendedB = (int)((originalColor.B * 0.7) + (newColor.B * 0.3));

            return Color.FromArgb(blendedR, blendedG, blendedB);
        }

        private Color InterpolateColor(Color color1, Color color2, float t)
        {
            int r = (int)(color1.R + (color2.R - color1.R) * t);
            int g = (int)(color1.G + (color2.G - color1.G) * t);
            int b = (int)(color1.B + (color2.B - color1.B) * t);

            return Color.FromArgb(r, g, b);
        }
    }
}
