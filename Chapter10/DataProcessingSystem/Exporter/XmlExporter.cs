using DataProcessingSystem.Domain;
using DataProcessingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessingSystem.Exporter
{
    public class XmlExporter : IExporter
    {
        public void Export(string path, List<Record> records)
        {
            var serializer = new XmlSerializer(typeof(List<Record>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, records);
            }
        }
    }
}
