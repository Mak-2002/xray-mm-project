using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    internal class GrayscaleFilter : IFilter
    {
        public Color ApplyFilter(int intensity)
        {
            return Color.FromArgb(intensity, intensity, intensity); // Convert to grayscale
        }
    }
}
