using AIPromptOrchestrationEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Steps
{
    public interface IStepCondition
    {
        bool ShouldExecute(StepContext context);
    }
}
