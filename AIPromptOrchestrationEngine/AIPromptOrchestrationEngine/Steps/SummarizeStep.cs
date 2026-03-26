using AIPromptOrchestrationEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Steps
{
    public class SummarizeStep : IStep
    {
        public string Name => "SUMMARIZE";
        public StepResult Execute(StepContext context)
        {
            return StepResult.Success("Summary of: " + context.Input);
        }
    }
}
