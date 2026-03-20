using CreatorMonetization.Interfaces;
using CreatorMonetization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization.Strategies
{
    public class BrandDealStrategy : IEarningStrategy
    {
        public string EarningType => "Brand Deal";

        public double Calculate(EarningContext context)
        {
            double engagementMultiplier;
            if (context.EngagementRate >= 0.10) engagementMultiplier = 1.5;
            else if (context.EngagementRate >= 0.05) engagementMultiplier = 1.2;
            else if (context.EngagementRate >= 0.02) engagementMultiplier = 1.0;
            else engagementMultiplier = 0.8;

            double seasonMultiplier = (context.Season == "FESTIVE") ? 1.3 : 1.0;

            return context.BaseAmount * engagementMultiplier * seasonMultiplier;
        }
    }
}
