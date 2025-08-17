using System;
using System.Collections.Generic;
using Nauman.AIPortfolioGenerator.Domain.Common;

namespace Nauman.AIPortfolioGenerator.Domain
{
    public class Portfolio : AuditableWithBaseEntity
    {
        public string UserId { get; set; }
        public Template Template { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public Dictionary<string, string> ThemeSettings { get; set; }
    }
}
