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
    public class LiveGiftStrategy : IEarningStrategy
    {
        private readonly double _giftValuePerViewer;
        private readonly double _platformCutPercent;
        public string EarningType => "Live Gifts";
        public LiveGiftStrategy(double giftValuePerViewer = 0.10, double platformCutPercent = 0.50)
        {
            _giftValuePerViewer = giftValuePerViewer;
            _platformCutPercent = platformCutPercent;
        }

        public double Calculate(EarningContext context)
        {
            double regionMultiplier = EarningMultipliers.GetGiftRegionMultiplier(context.Region);
            double engagementBonus = 1 + (context.EngagementRate * 2.0);
            double gross = context.Views * _giftValuePerViewer
                                        * regionMultiplier
                                        * engagementBonus;

            return gross * (1 - _platformCutPercent);
        }
    }
}
