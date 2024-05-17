using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    public interface IFilter
    {
        Color ApplyFilter(int intensity);
    }
}
