using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationGeoCoder.Models
{
    public class GeoLocation
    {
        public string FormattedAddress { get; init; } = string.Empty;
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}
