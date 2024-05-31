using System.Drawing;
using XRayImageProcessor.Filters;

namespace XRayImageProcessor.Logic
{
    public class FilterManager
    {
        private Dictionary<string, IFilter> filters = new Dictionary<string, IFilter>();
        public IFilter CurrentFilter { get; private set; }
        public CustomFilter customFilter { get; private set; }

        public FilterManager()
        {
            filters.Add("Tumor Progression", new TumorProgressionFilter());
            filters.Add("Contrast Enhancement", new ContrastEnhancementFilter());
            customFilter = new CustomFilter();
            filters.Add("Custom Color", customFilter);
        }

        public void SetCurrentFilter(string filterName)
        {
            if (filters.ContainsKey(filterName))
            {
                CurrentFilter = filters[filterName];
            }
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

                        Color newColor = CurrentFilter.ApplyFilter(originalColor);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
        }

        public string[] GetFilterNames()
        {
            return filters.Keys.ToArray();
        }

        internal void SetCustomFilterColor(Color color)
        {
            customFilter.SetColor(color);
        }
    }
}
