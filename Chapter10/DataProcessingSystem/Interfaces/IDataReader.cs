using DataProcessingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Interfaces
{
    public interface IDataReader
    {
        List<Record> Read(string filePath, List<string> errors);
    }
}
