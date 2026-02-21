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

            for (int i = 1; i <= count; i++)
            {
                lines.Add($"ID{i:D4},Item{i},{rnd.Next(10, 1000)},{DateTime.Now:yyyy-MM-dd}");
            }

            File.WriteAllLines(path, lines);
        }
    }
}
