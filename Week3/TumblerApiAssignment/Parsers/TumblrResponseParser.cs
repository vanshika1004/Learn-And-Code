using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TumblerApiAssignment.Interfaces;
using TumblerApiAssignment.Models;

namespace TumblerApiAssignment.Parsers
{
    public class TumblrResponseParser : ITumblrParser
    {

        public TumblrApiResponse Parse(string rawResponse)
        {
            string cleanJson = rawResponse
                .Replace("var tumblr_api_read = ", "")
                .TrimEnd(';');

            return JsonConvert.DeserializeObject<TumblrApiResponse>(cleanJson);
        }
    }
}
