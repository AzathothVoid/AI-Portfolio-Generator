using System;
using System.Collections.Generic;
using System.Text;
using Nauman.AIPortfolioGenerator.Domain.Common;

namespace Nauman.AIPortfolioGenerator.Domain
{
    public class Section : BaseEntity
    {
        public string Name { get; set; }
        public SectionType Type { get; set; }
        public string? Description { get; set; }
        public Portfolio Portfolio { get; set;}
        public Template Template { get; set; }
        public Dictionary<string, string> Data { get; set; }

    }

    public enum SectionType
    {
        Header,
        Hero,
        AboutMe,
        Experience,
        Projects,
        Contact,
        Footer
    }
}
