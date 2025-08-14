using System;
using System.Collections.Generic;
using System.Text;
using Nauman.AIPortfolioGenerator.Domain.Common;

namespace Nauman.AIPortfolioGenerator.Domain
{
    public class Template : AuditableWithBaseEntity
    {  
        public string Name { get; set; }
        public string Description { get; set; }
        public string[]? Keywords { get; set; }
        public string[] Themes { get; set; }
        public string[] Palette { get; set; }
        public bool IsPaid { get; set; }
    }
}
