using AIPromptOrchestrationEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Steps
{
    public class TranslateStep : IStep
    {
        public string Name => "TRANSLATE";
        public StepResult Execute(StepContext context)
        {
            return StepResult.Success("Translated: " + context.Input);
        }
    }
}
