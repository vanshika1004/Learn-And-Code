using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Models;

namespace TumblerApiAssignment.Interfaces
{
    public interface ITumblrPrinter
    {
        void PrintBlogInfo(TumblrApiResponse response);
        void PrintImages(TumblrApiResponse response, int startIndex);
    }
}
