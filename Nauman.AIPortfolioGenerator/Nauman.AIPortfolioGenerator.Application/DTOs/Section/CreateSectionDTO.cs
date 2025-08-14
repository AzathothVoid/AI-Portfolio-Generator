using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Section
{
    public class CreateSectionDTO : ISectionDTO
    {
        public string Name { get; set; }
        public SectionType Type { get; set; }
        public string? Description { get; set; }
        public int Portfolio { get; set; }
        public int Template { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
