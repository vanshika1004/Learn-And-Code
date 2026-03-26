using AIPromptOrchestrationEngine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine.Factories
{
    public class StepFactory
    {
        private readonly Dictionary<string, Func<IStep>> _steps;

        public StepFactory()
        {
            _steps = new Dictionary<string, Func<IStep>>
        {
            { "GENERATE", () => new GenerateStep() },
            { "SUMMARIZE", () => new SummarizeStep() },
            { "TRANSLATE", () => new TranslateStep() }
        };
        }

        public IStep Create(string stepType)
        {
            if (_steps.ContainsKey(stepType))
                return _steps[stepType]();

            throw new Exception($"Step {stepType} not found");
        }
    }
}
