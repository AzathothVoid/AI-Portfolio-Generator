using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio
{
    public class UpdatePortfolioDTO : IPortfolioDTO
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public Dictionary<string, string> ThemeSettings { get; set; }
    }
}
