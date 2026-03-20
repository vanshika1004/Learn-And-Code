using CreatorMonetization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization.Models
{
    public class Creator
    {
        private readonly List<IEarningStrategy> _strategies = new List<IEarningStrategy>();
        private string _name;

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Creator name cannot be empty.");
                _name = value;
            }
        }

        public string Category { get; }   

        public IReadOnlyList<IEarningStrategy> Strategies => _strategies.AsReadOnly();

        public Creator(string name, string category = "General")
        {
            Name = name;
            Category = category;
        }

        public Creator AddStrategy(IEarningStrategy strategy)
        {
            if (strategy == null) throw new ArgumentNullException(nameof(strategy));
            _strategies.Add(strategy);
            return this; 
        }

        public Creator RemoveStrategy(IEarningStrategy strategy)
        {
            _strategies.Remove(strategy);
            return this;
        }

        public double CalculateTotalEarnings(EarningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            double total = 0;
            foreach (var strategy in _strategies)
                total += strategy.Calculate(context);

            return total;
        }

        public Dictionary<string, double> GetEarningsBreakdown(EarningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var breakdown = new Dictionary<string, double>();
            foreach (var strategy in _strategies)
                breakdown[strategy.EarningType] = strategy.Calculate(context);

            return breakdown;
        }

        public void PrintEarningsReport(EarningContext context)
        {
            Console.WriteLine($"\n{'=',1}{'=',1}{'=',1} Earnings Report — {Name} ({Category}) {'=',1}{'=',1}{'=',1}");
            Console.WriteLine($"  Region: {context.Region}  |  Season: {context.Season}");
            Console.WriteLine(new string('-', 50));

            double total = 0;
            foreach (var strategy in _strategies)
            {
                double amount = strategy.Calculate(context);
                Console.WriteLine($"  {strategy.EarningType,-20} ${amount,10:N2}");
                total += amount;
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"  {"TOTAL",-20} ${total,10:N2}");
            Console.WriteLine();
        }
    }
}
