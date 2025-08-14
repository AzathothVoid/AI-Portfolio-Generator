using Nauman.AIPortfolioGenerator.Application.DTOs.Common;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Section
{
    public class SectionDTO : BaseDTO
    {
        public string Name { get; set; }
        public SectionType Type { get; set; }
        public string? Description { get; set; }
        public PortfolioDTO Portfolio { get; set; }
        public TemplateDTO Template { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
