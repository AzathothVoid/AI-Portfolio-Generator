using Nauman.AIPortfolioGenerator.Application.DTOs.Common;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio
{
    public class PortfolioDTO : BaseDTO, IPortfolioDTO
    {
        public string UserId { get; set; }
        public TemplateDTO Template { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public Dictionary<string, string> ThemeSettings { get; set; }
    }
}
