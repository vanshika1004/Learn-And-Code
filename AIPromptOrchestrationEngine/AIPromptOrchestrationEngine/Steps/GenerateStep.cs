using AIPromptOrchestrationEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Steps
{
    public class GenerateStep : IStep
    {
        public string Name => "GENERATE";
        public StepResult Execute(StepContext context)
        {
            return StepResult.Success("Generated: " + context.Input);
        }
    }
}
