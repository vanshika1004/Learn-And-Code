using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Configuration
{
    public class ProcessorConfiguration
    {
        public bool ValidateData { get; set; } = true;
        public bool TransformData { get; set; } = true;
        public string DateFormat { get; set; } = "yyyy-MM-dd";
        public int BatchSize { get; set; } = 100;
    }
}
