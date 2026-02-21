using DataProcessingSystem.Configuration;
using DataProcessingSystem.Exporter;
using DataProcessingSystem.Logger;
using DataProcessingSystem.Reader;
using DataProcessingSystem.Services;
using DataProcessingSystem.Transformer;
using DataProcessingSystem.Utilities;
using DataProcessingSystem.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SampleDataGenerator.Generate("input.csv", 50);

            var config = new ProcessorConfiguration
            {
                ValidateData = true,
                TransformData = true,
                DateFormat = "MM/dd/yyyy"
            };

            var processor = new DataProcessor(
                new CsvDataReader(),
                new RecordValidator(),
                new RecordTransformer(),
                new FileLogger("processing.log")
            );

            var records = processor.Process("input.csv", config);

            new CsvExporter().Export("output.csv", records);
            new JsonExporter().Export("output.json", records);
            new XmlExporter().Export("output.xml", records);

            Console.WriteLine($"Records processed: {processor.RecordsProcessed}");
            Console.WriteLine($"Errors: {processor.ErrorCount}");
        }
    }
}
