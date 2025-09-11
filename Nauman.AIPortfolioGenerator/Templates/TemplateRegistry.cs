using Templates.Template1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public record TemplateInfo(int Id, string Name, string PreviewUrl, Type RootComponent);
    public static class TemplateRegistry
    {
        public static IReadOnlyList<TemplateInfo> All { get; } = new[]
        {
          
            new TemplateInfo(
                Id: 1,
                Name: "Modern One",
                PreviewUrl: "/_content/Templates/preview/modern-one.png",
                RootComponent: typeof(Templates.Template1.Root) 
            ),           
        };
    }
}
