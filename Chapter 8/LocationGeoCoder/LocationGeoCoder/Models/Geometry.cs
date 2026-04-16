using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationGeoCoder.Models
{
    internal sealed class Geometry
    {
        [JsonPropertyName("location")]
        public LatLng Location { get; init; } = new();
    }
}
