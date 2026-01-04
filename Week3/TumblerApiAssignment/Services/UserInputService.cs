using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblerApiAssignment.Interfaces;
using TumblerApiAssignment.Models;

namespace TumblerApiAssignment.Services
{
    public class UserInputService : IUserInputService
    {
        public UserInput ReadInput()
        {
            Console.WriteLine("Enter the Tumblr blog name:");
            string blogName = Console.ReadLine()?.Trim();

            Console.WriteLine("\nEnter the post range (start-end):");
            string range = Console.ReadLine()?.Trim();

            string[] parts = range.Split('-');
            int start = int.Parse(parts[0]);
            int end = int.Parse(parts[1]);

            return new UserInput
            {
                BlogName = blogName,
                StartIndex = start,
                Start = start - 1,
                Count = end - start + 1
            };
        }
    }
}
