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

            // Define gradient colors for different intensity ranges
            Color lowColor = Color.Red;         // Red for low intensity (dark areas)
            Color midColor = Color.Orange;      // Orange for mid intensity
            Color highColor = Color.Green;      // Green for high intensity (light areas)

            if (intensity < 85)
            {
                // Interpolate between lowColor and midColor
                float t = intensity / 85f;
                newColor = InterpolateColor(lowColor, midColor, t);
            }
            else if (intensity < 170)
            {
                // Interpolate between midColor and highColor
                float t = (intensity - 85) / 85f;
                newColor = InterpolateColor(midColor, highColor, t);
            }
            else
            {
                // For intensity above 170, we just use highColor directly to highlight the most affected areas.
                newColor = highColor;
            }

            // Blend the original color with the new color for some preservation of details
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
