using CreatorMonetization.Interfaces;
using CreatorMonetization.Models;
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
            double regionMultiplier;
            if (context.Region == "US") regionMultiplier = 1.8;
            else if (context.Region == "EU") regionMultiplier = 1.3;
            else if (context.Region == "IN") regionMultiplier = 0.5;
            else regionMultiplier = 1.0;

            double engagementBonus = 1 + (context.EngagementRate * 2.0);

            double gross = context.Views * _giftValuePerViewer
                                        * regionMultiplier
                                        * engagementBonus;

            return gross * (1 - _platformCutPercent);
        }
    }
}
