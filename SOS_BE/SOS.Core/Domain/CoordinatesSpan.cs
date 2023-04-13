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
        public int LatitudeStart { get; set; }
        public int LongitudeStart { get; set; }
        public int LatitudeEnd { get; set; }
        public int LongitudeEnd { get; set;}
    }
}
