using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingSystem.Domain
{
    public class ValidationResult
    {
        public List<string> Errors { get; } = new List<string>();
        public bool IsValid => Errors.Count == 0;
    }
}
