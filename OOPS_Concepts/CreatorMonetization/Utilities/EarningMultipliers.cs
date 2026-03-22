using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization.Utilities
{
    public static class EarningMultipliers
    {
        // Region multipliers 
        private static readonly Dictionary<string, double> RegionRates
            = new Dictionary<string, double>
            {
                { "US", 1.5 },
                { "EU", 1.2 },
                { "IN", 0.6 },
                { "UK", 1.3 },
                { "AU", 1.1 },
            };

        // Season multipliers 
        private static readonly Dictionary<string, double> SeasonRates
            = new Dictionary<string, double>
            {
                { "FESTIVE",   1.4 },
                { "OFFSEASON", 0.7 },
                { "REGULAR",   1.0 },
            };

        // Gift region multipliers (higher — US viewers gift more)
        private static readonly Dictionary<string, double> GiftRegionRates
            = new Dictionary<string, double>
            {
                { "US", 1.8 },
                { "EU", 1.3 },
                { "IN", 0.5 },
                { "UK", 1.4 },
                { "AU", 1.2 },
            };

        // Engagement multipliers
        private static readonly List<(double MinRate, double Multiplier)> EngagementTiers
        = new List<(double, double)>
        {
            (0.10, 1.5),   // viral-tier engagement
            (0.05, 1.2),   // strong engagement
            (0.02, 1.0),   // average engagement
            (0.00, 0.8),   // low engagement
        };

        public static double GetRegionMultiplier(string region)
        {
            if (RegionRates.TryGetValue(region ?? string.Empty, out double rate))
                return rate;
            return 1.0;
        }

        public static double GetSeasonMultiplier(string season)
        {
            if (SeasonRates.TryGetValue(season ?? string.Empty, out double rate))
                return rate;
            return 1.0;
        }

        public static double GetGiftRegionMultiplier(string region)
        {
            if (GiftRegionRates.TryGetValue(region ?? string.Empty, out double rate))
                return rate;
            return 1.0;
        }

        public static double GetEngagementMultiplier(double engagementRate)
        {
            foreach (var (minRate, multiplier) in EngagementTiers)
            {
                if (engagementRate >= minRate)
                    return multiplier;
            }
            return 0.8; 
        }
    }
}
