using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationGeoCoder.Models
{
    internal sealed class GeocodeResult
    {
        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; init; } = string.Empty;

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; init; } = new();
    }
}
