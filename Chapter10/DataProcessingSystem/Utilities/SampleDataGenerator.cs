using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Utilities
{
    public static class SampleDataGenerator
    {
        public static void Generate(string path, int count)
        {
            var lines = new List<string>();
            var rnd = new Random();

            for (int index = 1; index <= count; index++)
            {
                lines.Add($"ID{index:D4},Item{index},{rnd.Next(10, 1000)},{DateTime.Now:yyyy-MM-dd}");
            }

            File.WriteAllLines(path, lines);
        }
    }
}
