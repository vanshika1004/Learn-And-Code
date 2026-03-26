using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Models
{
    public class StepConfig
    {
        public IStep Step { get; set; }
        public int RetryCount { get; set; } = 0;
        public IRetryCondition RetryCondition { get; set; }
        public IStep FallbackStep { get; set; }
        public IStepCondition Condition { get; set; }
    }
}
