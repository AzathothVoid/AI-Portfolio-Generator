using System;
using System.Collections.Generic;
using Nauman.AIPortfolioGenerator.Domain.Common;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Domain
{
    public class User : AuditableWithBaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool isPremium { get; set; }
    }
}
