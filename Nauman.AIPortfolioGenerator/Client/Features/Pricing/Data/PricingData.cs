using Client.Features.Pricing.Models;
using System.Collections.Generic;

namespace Client.Features.Pricing.Data
{
    public static class PricingData
    {
        // Starter (cardData1)
        public static List<PricingCard> CardData1 { get; } = new()
        {
            new PricingCard
            {
                Title = "Starter",
                Lines = new List<string> { "Any three templete are free to use" },
                Price = "Free",
                CardBackgroundClass = "bg-white"
            }
        };

        // Pro (cardData2)
        public static List<PricingCard> CardData2 { get; } = new()
        {
            new PricingCard
            {
                ImageUrl = "https://i.imgur.com/pJNFEHR.png",
                Title = "Pro",
                Lines = new List<string> { "+Four Templetes are included", "+Additional Design Features" },
                Price = "20",
                PricePrefix = "$",
                CardBackgroundClass = "bg-blue-400 text-white"
            }
        };

        // Business+ (cardData3)
        public static List<PricingCard> CardData3 { get; } = new()
        {
            new PricingCard
            {
                ImageUrl = "https://i.imgur.com/Hg0sUJP.png",
                Title = "Business+",
                Lines = new List<string>
                {
                    "For companies that need to",
                    "manage work happening",
                    "accross multiple teams"
                },
                Price = "100",
                PricePrefix = "$",
                CardBackgroundClass = "bg-white"
            }
        };
    }
}
