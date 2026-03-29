using DataProcessingSystem.Domain;
using DataProcessingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Exporter
{
    public class CsvExporter : IExporter
    {
        public void Export(string path, List<Record> records)
        {
            var lines = new List<string>
        {
            "ID,NAME,VALUE,DATE,DOUBLED_VALUE,SQUARED_VALUE"
        };

            lines.AddRange(records.Select(record =>
                $"{record.Id},{record.Name},{record.Value},{record.Date},{record.DoubledValue},{record.SquaredValue}"));

            File.WriteAllLines(path, lines);
        }
    }
}
