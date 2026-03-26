using AIPromptOrchestrationEngine.Models;
using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Conditions
{
    public class NonEmptyInputCondition : IStepCondition
    {
        public bool ShouldExecute(StepContext context)
        {
            return !string.IsNullOrWhiteSpace(context.Input);
        }
    }
}
