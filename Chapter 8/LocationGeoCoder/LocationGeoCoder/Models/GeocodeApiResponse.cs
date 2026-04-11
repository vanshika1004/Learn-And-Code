using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationGeoCoder.Models
{
    internal sealed class GeocodeApiResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; init; } = string.Empty;

        [JsonPropertyName("results")]
        public List<GeocodeResult> Results { get; init; } = [];
    }

    internal sealed class GeocodeResult
    {
        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; init; } = string.Empty;

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; init; } = new();
    }

    internal sealed class Geometry
    {
        [JsonPropertyName("location")]
        public LatLng Location { get; init; } = new();
    }

    internal sealed class LatLng
    {
        [JsonPropertyName("lat")]
        public double Lat { get; init; }

        [JsonPropertyName("lng")]
        public double Lng { get; init; }
    }
}
