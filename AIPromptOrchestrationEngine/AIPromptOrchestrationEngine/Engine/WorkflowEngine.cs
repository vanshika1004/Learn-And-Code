using AIPromptOrchestrationEngine.Handlers;
using AIPromptOrchestrationEngine.Models;
using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Engine
{
    public class WorkflowEngine
    {
        private readonly ILogger _logger;
        private readonly ConditionalRetryHandler _retryHandler;
        private readonly FallbackHandler _fallbackHandler;

        public WorkflowEngine(ILogger logger)
        {
            _logger = logger;
            _retryHandler = new ConditionalRetryHandler();
            _fallbackHandler = new FallbackHandler();
        }

        public string Run(List<StepConfig> steps, string input)
        {
            var context = new StepContext { Input = input };

            foreach (var config in steps)
            {
                // Conditional Step Execution
                if (config.Condition != null &&
                    !config.Condition.ShouldExecute(context))
                {
                    _logger.Log($"Skipping Step: {config.Step.Name}");
                    continue;
                }

                _logger.Log($"Executing Step: {config.Step.Name}");

                StepResult result;

                // Retry Logic
                if (config.RetryCount > 0)
                {
                    result = _retryHandler.Execute(
                        config.Step,
                        context,
                        config.RetryCount,
                        config.RetryCondition
                    );
                }
                else
                {
                    result = config.Step.Execute(context);
                }

                // Fallback Logic
                if (!result.IsSuccess && config.FallbackStep != null)
                {
                    _logger.Log($"Fallback triggered for {config.Step.Name}");

                    result = _fallbackHandler.Execute(
                        config.Step,
                        config.FallbackStep,
                        context
                    );
                }

                if (!result.IsSuccess)
                {
                    _logger.Log($"Step failed: {config.Step.Name}");
                    break;
                }

                context.Input = result.Output;
                context.Trace.Add($"Executed: {config.Step.Name}");
            }

            return context.Input;
        }
    }
}
