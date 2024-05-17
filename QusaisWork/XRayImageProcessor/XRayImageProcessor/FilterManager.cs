using System.Drawing;
using XRayImageProcessor.Filters;

namespace XRayImageProcessor
{
    public class FilterManager
    {
        private Dictionary<string, IFilter> filters = new Dictionary<string, IFilter>();
        public IFilter CurrentFilter { get; private set; }

        public FilterManager()
        {
            filters.Add("Tumor Progression", new TumorProgressionFilter());
            filters.Add("Grayscale", new GrayscaleFilter());
        }

        public void SetCurrentFilter(string filterName)
        {
            CurrentFilter = filters[filterName];
        }

        public void ApplyFilterToRegion(Bitmap bmp, Rectangle region)
        {
            for (int x = region.Left; x < region.Right; x++)
            {
                for (int y = region.Top; y < region.Bottom; y++)
                {
                    if (x >= 0 && y >= 0 && x < bmp.Width && y < bmp.Height)
                    {
                        Color originalColor = bmp.GetPixel(x, y);
                        int intensity = (int)((originalColor.R + originalColor.G + originalColor.B) / 3.0);
                        Color newColor = CurrentFilter.ApplyFilter(intensity);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
        }

        public string[] GetFilterNames()
        {
            return filters.Keys.ToArray();
        }
    }
}
