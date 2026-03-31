using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumblerApiAssignment.Models
{
    // Root model representing the JSON response returned by Tumblr API v1
    public class TumblrApiResponse
    {
        public Tumblelog tumblelog { get; set; }
        public List<Post> posts { get; set; }
    }

    // Contains basic metadata about the Tumblr blog
    public class Tumblelog
    {
        public string title { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        // Total number of posts available on the blog.
        public int posts { get; set; }
    }

    public class Post
    {
        // A single post may contain multiple photos.
        public List<Photo> photos { get; set; }
    }

    public class Photo
    {
        /* Tumblr API uses hyphenated JSON keys.
         This attribute maps the highest-quality image (1280 resolution) */
        [JsonProperty("photo-url-1280")]
        public string photo_url_1280 { get; set; }
    }
}
