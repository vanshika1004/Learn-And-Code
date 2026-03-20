using CreatorMonetization.Interfaces;
using CreatorMonetization.Models;
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
            double regionMultiplier;
            if (context.Region == "US") regionMultiplier = 1.5;
            else if (context.Region == "EU") regionMultiplier = 1.2;
            else if (context.Region == "IN") regionMultiplier = 0.6;
            else regionMultiplier = 1.0;

            double seasonMultiplier;
            if (context.Season == "FESTIVE") seasonMultiplier = 1.4;
            else if (context.Season == "OFFSEASON") seasonMultiplier = 0.7;
            else seasonMultiplier = 1.0;

            double engagementBonus = 1 + (context.EngagementRate * 0.5);

            return context.Views * _baseCpmRate * regionMultiplier
                                                * seasonMultiplier
                                                * engagementBonus;
        }
    }
}
