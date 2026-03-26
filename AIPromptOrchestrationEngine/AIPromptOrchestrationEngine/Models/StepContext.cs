using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Models
{
    public class StepContext
    {
        public string Input { get; set; }
        public List<string> Trace { get; set; } = new List<string>();
    }
}
