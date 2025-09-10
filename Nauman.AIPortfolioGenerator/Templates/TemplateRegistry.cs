using Templates.Template1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public record TemplateInfo(string Id, string Name, string PreviewUrl, Type RootComponent);
    public static class TemplateRegistry
    {
        public static IReadOnlyList<TemplateInfo> All { get; } = new[]
        {
          
            new TemplateInfo(
                Id: "modern-one",
                Name: "Modern One",
                PreviewUrl: "/_content/Nauman.AIPortfolioGenerator.Templates/preview/modern-one.png",
                RootComponent: typeof(Templates.Template1.Root) 
            ),           
        };
    }
}
