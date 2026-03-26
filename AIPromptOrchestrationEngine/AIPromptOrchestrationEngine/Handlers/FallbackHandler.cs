using AIPromptOrchestrationEngine.Models;
using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Handlers
{
    public class FallbackHandler
    {
        public StepResult Execute(IStep step, IStep fallback, StepContext context)
        {
            var result = step.Execute(context);

            if (!result.IsSuccess && fallback != null)
            {
                return fallback.Execute(context);
            }

            return result;
        }
    }
}
