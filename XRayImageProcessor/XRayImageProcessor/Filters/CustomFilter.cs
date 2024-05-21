using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    public class CustomFilter : IFilter
    {
        private Color chosenColor;

        public CustomFilter()
        {
            chosenColor = Color.Gray;
        }

        public void SetColor(Color color)
        {
            chosenColor = color;
        }

        public Color ApplyFilter(Color originalColor)
        {
            int intensity = (int)((originalColor.R + originalColor.G + originalColor.B) / 3.0);

            int r = (int)(chosenColor.R * (intensity / 255.0));
            int g = (int)(chosenColor.G * (intensity / 255.0));
            int b = (int)(chosenColor.B * (intensity / 255.0));

            return Color.FromArgb(r, g, b);
        }
    }
}
