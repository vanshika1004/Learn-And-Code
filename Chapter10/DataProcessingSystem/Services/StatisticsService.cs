using DataProcessingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Services
{
    public class StatisticsService
    {
        public Dictionary<string, int> Calculate(List<Record> records, int errorCount)
        {
            double total = records.Sum(record => record.Value);

            return new Dictionary<string, int>
        {
            { "total_records", records.Count },
            { "error_count", errorCount },
            { "total_value", (int)total },
            { "average_value", records.Count > 0 ? (int)(total / records.Count) : 0 }
        };
        }
    }
}
