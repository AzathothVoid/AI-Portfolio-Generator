namespace Client.Features.Pricing.Models
{
    public class PricingCard
    {
        public string Title { get; set; } = string.Empty;
        public List<string> Lines { get; set; } = new();
        public string? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? PricePrefix { get; set; }
        public string? CardBackgroundClass { get; set; }
    }
}
