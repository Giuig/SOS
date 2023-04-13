using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Domain
{
    public class CoordinatesSpan
    {
        public int Id { get; set; }
        public double LatitudeStart { get; set; }
        public double LongitudeStart { get; set; }
        public double LatitudeEnd { get; set; }
        public double LongitudeEnd { get; set;}
    }
}
