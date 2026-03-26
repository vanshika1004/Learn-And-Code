using AIPromptOrchestrationEngine.Models;
using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Handlers
{
    public class ConditionalRetryHandler
    {
        public StepResult Execute(
            IStep step,
            StepContext context,
            int maxRetries,
            IRetryCondition condition)
        {
            StepResult result = null;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                result = step.Execute(context);

                if (result.IsSuccess)
                    return result;

                if (condition == null || !condition.ShouldRetry(result, attempt))
                    break;
            }

            return result ?? StepResult.Failure("Execution failed");
        }
    }
}
