using DataProcessingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Interfaces
{
    public interface IExporter
    {
        void Export(string filePath, List<Record> records);
    }
}
