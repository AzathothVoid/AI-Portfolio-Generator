using Client.Features.Landing.Components.Categories.Models;

namespace Client.Features.Landing.Components.Categories.Data
{
    public static class TemplateData
    {
        public static IEnumerable<TemplateDetail> Sample()
        {
            return new List<TemplateDetail>
            {
                new TemplateDetail { Template = "template1.png", Name = "template1", Text = "Minimal portfolio", Category = "Light", Stars = 4 },
                new TemplateDetail { Template = "template2.png", Name = "template2", Text = "Dark creative", Category = "Dark", Stars = 5 },
                new TemplateDetail { Template = "template3.png", Name = "template3", Text = "No-code builder", Category = "NoCode", Stars = 3 },
                new TemplateDetail { Template = "template4.png", Name = "template4", Text = "Developer portfolio", Category = "Code", Stars = 4 },
                new TemplateDetail { Template = "template5.png", Name = "template5", Text = "Modern CV site", Category = "Light", Stars = 3 },
            };
        }
    }
}
