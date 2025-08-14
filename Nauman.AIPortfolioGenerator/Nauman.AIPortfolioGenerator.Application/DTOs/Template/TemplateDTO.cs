using Nauman.AIPortfolioGenerator.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Template
{
    public class TemplateDTO : BaseDTO, ITemplateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[]? Keywords { get; set; }
        public string[] Themes { get; set; }
        public string[] Palette { get; set; }
        public bool IsPaid { get; set; }
    }
}
