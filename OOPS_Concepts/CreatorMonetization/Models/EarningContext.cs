using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization.Models
{
    public class EarningContext
    {
        public int Views { get; }
        public int Subscribers { get; }
        public double EngagementRate { get; }  // 0.0 – 1.0
        public double BaseAmount { get; }  
        public string Region { get; }  
        public string Season { get; }  

        public EarningContext(
            int views,
            int subscribers,
            double engagementRate,
            double baseAmount,
            string region = "US",
            string season = "REGULAR")
        {
            if (views < 0) throw new ArgumentOutOfRangeException(nameof(views));
            if (subscribers < 0) throw new ArgumentOutOfRangeException(nameof(subscribers));
            if (engagementRate < 0 || engagementRate > 1)
                throw new ArgumentOutOfRangeException(nameof(engagementRate), "Must be 0.0 – 1.0");
            if (baseAmount < 0) throw new ArgumentOutOfRangeException(nameof(baseAmount));

            Views = views;
            Subscribers = subscribers;
            EngagementRate = engagementRate;
            BaseAmount = baseAmount;
            Region = region ?? "US";
            Season = season ?? "REGULAR";
        }
    }
}
