using DataProcessingSystem.Domain;
using DataProcessingSystem.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DataProcessingSystem.Exporter
{
    public class JsonExporter : IExporter
    {
        public void Export(string path, List<Record> records)
        {
            string json = JsonConvert.SerializeObject(
                records,
                Newtonsoft.Json.Formatting.Indented
            );

            File.WriteAllText(path, json);
        }
    }
}