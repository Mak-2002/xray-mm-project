using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    internal class TumorProgressionFilter : IFilter
    {
        public Color ApplyFilter(int intensity)
        {
            if (intensity < 85)
            {
                return Color.FromArgb(255, 0, 0); // Dark areas (potentially tumors) are colored red
            }
            else if (intensity < 170)
            {
                return Color.FromArgb(255, 165, 0); // Mid intensity areas are colored orange
            }
            else
            {
                return Color.FromArgb(0, 255, 0); // Light areas are colored green
            }
        }
    }
}
