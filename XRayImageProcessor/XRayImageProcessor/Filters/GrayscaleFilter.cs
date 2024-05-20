﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    internal class GrayscaleFilter : IFilter
    {
        // useless filter
        public Color ApplyFilter(Color originalColor)
        {
            int intensity = (int)((originalColor.R + originalColor.G + originalColor.B) / 3.0);
            return Color.FromArgb(intensity, intensity, intensity); // Convert to grayscale
        }
    }
}