using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Models;

namespace TumblerApiAssignment.Interfaces
{
    internal interface ITumblrParser
    {
        TumblrApiResponse Parse(string rawResponse);
    }
}
