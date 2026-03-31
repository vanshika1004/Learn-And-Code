using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblerApiAssignment.Interfaces
{
    public interface ITumblrService
    {
        Task<string> GetPostsAsync(string blogName, int start, int count);
    }
}
