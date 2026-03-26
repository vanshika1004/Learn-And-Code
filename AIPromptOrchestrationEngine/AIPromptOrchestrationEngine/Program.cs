using AIPromptOrchestrationEngine.Conditions;
using AIPromptOrchestrationEngine.Engine;
using AIPromptOrchestrationEngine.Factories;
using AIPromptOrchestrationEngine.Logging;
using AIPromptOrchestrationEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPromptOrchestrationEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new StepFactory();
            var logger = new ConsoleLogger();
            var engine = new WorkflowEngine(logger);

            string productDetails =
                "Product: iPhone 15, Category: Smartphone, Features: A16 Chip, 48MP Camera, Price: $999";

            var steps = new List<StepConfig>
            {
                new StepConfig
                {
                    Step = factory.Create("GENERATE"),
                    RetryCount = 2,
                    RetryCondition = new TimeoutRetryCondition()
                },
                new StepConfig
                {
                    Step = factory.Create("SUMMARIZE"),
                    Condition = new NonEmptyInputCondition()
                },
                new StepConfig
                {
                    Step = factory.Create("TRANSLATE"),
                    FallbackStep = factory.Create("GENERATE")
                }
            };

            var result = engine.Run(steps, productDetails);

            Console.WriteLine("\nFinal Output:");
            Console.WriteLine(result);
        }
    }
}
