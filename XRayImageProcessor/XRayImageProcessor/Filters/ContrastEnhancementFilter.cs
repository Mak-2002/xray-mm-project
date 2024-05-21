using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    internal class ContrastEnhancementFilter : IFilter
    {
        public Color ApplyFilter(Color originalColor)
        {
            int intensity = (int)((originalColor.R + originalColor.G + originalColor.B) / 3.0);

            int contrastLevel = 2;
            int newIntensity = (intensity - 128) * contrastLevel + 128;
            newIntensity = Math.Max(0, Math.Min(255, newIntensity));

            return Color.FromArgb(newIntensity, newIntensity, newIntensity);
        }
    }
}
