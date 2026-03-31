using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Interfaces;
using TumblerApiAssignment.Models;
using TumblerApiAssignment.Parsers;
using TumblerApiAssignment.Printers;
using TumblerApiAssignment.Services;

namespace TumblerApiAssignment
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                IUserInputService inputService = new UserInputService();
                ITumblrService tumblrService = new TumblrApiService();
                ITumblrParser parser = new TumblrResponseParser();
                ITumblrPrinter printer = new TumblrPrinter();

                // Read inputs
                var input = inputService.ReadInput();

                // Fetch raw response
                string rawResponse = await tumblrService.GetPostsAsync(
                    input.BlogName,
                    input.Start,
                    input.Count
                );

                // Parse response
                TumblrApiResponse response = parser.Parse(rawResponse);

                // Print output
                printer.PrintBlogInfo(response);
                printer.PrintImages(response, input.StartIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
