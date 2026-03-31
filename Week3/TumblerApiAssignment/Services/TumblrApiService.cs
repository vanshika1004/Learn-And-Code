using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Interfaces;

namespace TumblerApiAssignment.Services
{
    public class TumblrApiService : ITumblrService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> GetPostsAsync(string blogName, int start, int count)
        {
            string url =
                $"https://{blogName}.tumblr.com/api/read/json?type=photo&start={start}&num={count}";

            return await _httpClient.GetStringAsync(url);
        }
    }
}
