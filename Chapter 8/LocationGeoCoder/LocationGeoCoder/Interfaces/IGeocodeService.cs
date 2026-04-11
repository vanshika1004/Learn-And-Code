using LocationGeoCoder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationGeoCoder.Interfaces
{
    public interface IGeocodeService
    {
        Task<IReadOnlyList<GeoLocation>> GetLocationsAsync(string locationName);
    }
}
