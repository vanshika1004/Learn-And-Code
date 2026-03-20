using CreatorMonetization.Models;
using CreatorMonetization.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorMonetization
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Creator Monetization Platform ===\n");

            // Creator 1: Tech YouTuber — ads + brand deals + subscriptions 
            var techCreator = new Creator("Rahul Sharma", "Tech");

            techCreator
                .AddStrategy(new AdRevenueStrategy(baseCpmRate: 0.05))
                .AddStrategy(new SubscriptionStrategy(monthlyFee: 4.99, platformCutPercent: 0.30))
                .AddStrategy(new BrandDealStrategy());

            var usRegularContext = new EarningContext(
                views: 500_000,
                subscribers: 8_000,
                engagementRate: 0.07,   
                baseAmount: 15_000, 
                region: "US",
                season: "REGULAR"
            );

            techCreator.PrintEarningsReport(usRegularContext);

            // Same creator during festive season — higher ad rates + brand bonuses
            var usFestiveContext = new EarningContext(
                views: 800_000,
                subscribers: 8_000,
                engagementRate: 0.09,
                baseAmount: 15_000,
                region: "US",
                season: "FESTIVE"
            );

            Console.WriteLine("-- Same creator, festive season --");
            techCreator.PrintEarningsReport(usFestiveContext);

            // Creator 2: Indian Lifestyle creator — subscriptions + live gifts 
            var lifestyleCreator = new Creator("Priya Singh", "Lifestyle");

            lifestyleCreator
                .AddStrategy(new SubscriptionStrategy(monthlyFee: 1.99))
                .AddStrategy(new LiveGiftStrategy(giftValuePerViewer: 0.08));

            var inContext = new EarningContext(
                views: 200_000,
                subscribers: 12_000,
                engagementRate: 0.12,   
                baseAmount: 0,
                region: "IN",
                season: "FESTIVE"
            );

            lifestyleCreator.PrintEarningsReport(inContext);

            // Creator 3: All four income streams 
            var topCreator = new Creator("Alex Rivers", "Gaming");

            topCreator
                .AddStrategy(new AdRevenueStrategy(baseCpmRate: 0.07))
                .AddStrategy(new SubscriptionStrategy(monthlyFee: 9.99, platformCutPercent: 0.30))
                .AddStrategy(new BrandDealStrategy())
                .AddStrategy(new LiveGiftStrategy(giftValuePerViewer: 0.15));

            var euFestiveContext = new EarningContext(
                views: 2_000_000,
                subscribers: 50_000,
                engagementRate: 0.08,
                baseAmount: 50_000,
                region: "EU",
                season: "FESTIVE"
            );

            topCreator.PrintEarningsReport(euFestiveContext);

            //  Extensibility — add a new strategy to an existing creator 
            Console.WriteLine(">> Adding Live Gifts to Rahul (no existing code changed)");
            techCreator.AddStrategy(new LiveGiftStrategy());
            techCreator.PrintEarningsReport(usRegularContext);
        }
    }
}
