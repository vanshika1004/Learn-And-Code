using AIPromptOrchestrationEngine.Models;
using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Conditions
{
    public class TimeoutRetryCondition : IRetryCondition
    {
        public bool ShouldRetry(StepResult result, int attempt)
        {
            return !result.IsSuccess &&
                   result.Error != null &&
                   result.Error.Contains("timeout");
        }
    }
}
