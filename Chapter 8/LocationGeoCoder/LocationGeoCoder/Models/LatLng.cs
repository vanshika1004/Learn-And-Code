using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationGeoCoder.Models
{
    internal sealed class LatLng
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; init; }

        [JsonPropertyName("longtitude")]
        public double Longtitude { get; init; }
    }
}
