using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Domain.Common
{
    public interface IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
