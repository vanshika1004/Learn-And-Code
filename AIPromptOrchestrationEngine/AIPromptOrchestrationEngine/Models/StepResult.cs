using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Models
{
    public class StepResult
    {
        public bool IsSuccess { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
        public static StepResult Success(string output)
        {
            return new StepResult { IsSuccess = true, Output = output };
        }

        public static StepResult Failure(string error)
        {
            return new StepResult { IsSuccess = false, Error = error };
        }
    }
}
