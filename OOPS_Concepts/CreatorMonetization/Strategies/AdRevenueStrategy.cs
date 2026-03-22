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
    public class AdRevenueStrategy : IEarningStrategy
    {
        // cost per 1000 views
        private readonly double _baseCpmRate;  

        public string EarningType => "Ad Revenue";

        public AdRevenueStrategy(double baseCpmRate = 0.05)
        {
            if (baseCpmRate < 0)
                throw new ArgumentOutOfRangeException(nameof(baseCpmRate));
            _baseCpmRate = baseCpmRate;
        }

        public double Calculate(EarningContext context)
        {
            double regionMultiplier = EarningMultipliers.GetRegionMultiplier(context.Region);
            double seasonMultiplier = EarningMultipliers.GetSeasonMultiplier(context.Season);
            double engagementBonus = 1 + (context.EngagementRate * 0.5);

            return context.Views * _baseCpmRate * regionMultiplier
                                                * seasonMultiplier
                                                * engagementBonus;
        }
    }
}
