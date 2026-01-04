using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Interfaces;
using TumblerApiAssignment.Models;

namespace TumblerApiAssignment.Printers
{
    public class TumblrPrinter : ITumblrPrinter
    {
        public void PrintBlogInfo(TumblrApiResponse response)
        {
            Console.WriteLine("\n----------------------------------\n");
            Console.WriteLine($"title: {response.tumblelog.title}");
            Console.WriteLine($"name: {response.tumblelog.name}");
            Console.WriteLine($"description: {response.tumblelog.description}");
            Console.WriteLine($"no of post: {response.tumblelog.posts}\n");
        }

        public void PrintImages(TumblrApiResponse response, int startIndex)
        {
            int postNo = startIndex;

            foreach (var post in response.posts)
            {
                if (post.photos == null) continue;

                Console.WriteLine($"{postNo}.");
                foreach (var photo in post.photos)
                {
                    Console.WriteLine(photo.photo_url_1280);
                }

                postNo++;
            }
        }
    }
}
