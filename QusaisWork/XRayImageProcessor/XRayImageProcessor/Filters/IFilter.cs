using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRayImageProcessor.Filters
{
    internal interface IFilter
    {
        Color ApplyFilter(int intensity);
    }
}
