using CreatorMonetization.Interfaces;
using CreatorMonetization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization.Strategies
{
    public class SubscriptionStrategy : IEarningStrategy
    {
        private readonly double _monthlyFee;
        private readonly double _platformCutPercent;  

        public string EarningType => "Subscriptions";

        public SubscriptionStrategy(double monthlyFee = 2.0, double platformCutPercent = 0.30)
        {
            if (monthlyFee < 0) throw new ArgumentOutOfRangeException(nameof(monthlyFee));
            if (platformCutPercent < 0 || platformCutPercent > 1)
                throw new ArgumentOutOfRangeException(nameof(platformCutPercent));

            _monthlyFee = monthlyFee;
            _platformCutPercent = platformCutPercent;
        }

        public double Calculate(EarningContext context)
        {
            double creatorShare = _monthlyFee * (1 - _platformCutPercent);

            double retentionMultiplier = 1 + (context.EngagementRate * 0.2);

            return context.Subscribers * creatorShare * retentionMultiplier;
        }
    }
}
