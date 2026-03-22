using CreatorMonetization.Interfaces;
using CreatorMonetization.Models;
using CreatorMonetization.Utilities;
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
            double engagementMultiplier = EarningMultipliers.GetEngagementMultiplier(context.EngagementRate);
            double seasonMultiplier = (context.Season == "FESTIVE") ? 1.3 : 1.0;

            return context.BaseAmount * engagementMultiplier * seasonMultiplier;
        }
    }
}
