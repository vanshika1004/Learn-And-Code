using DataProcessingSystem.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using DataProcessingSystem.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Reader
{
    public class CsvDataReader : IDataReader
    {
        public List<Record> Read(string filePath, List<string> errors)
        {
            var records = new List<Record>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');

                if (parts.Length < 3)
                {
                    errors.Add($"Invalid line format: {line}");
                    continue;
                }

                if (!double.TryParse(parts[2], out var value))
                {
                    errors.Add($"Invalid value: {line}");
                    continue;
                }

                records.Add(new Record
                {
                    Id = parts[0].Trim(),
                    Name = parts[1].Trim(),
                    Value = value,
                    Date = parts.Length >= 4 ? (DateTime?)DateTime.Parse(parts[3]) : null
                });
            }

            return records;
        }
    }
}
