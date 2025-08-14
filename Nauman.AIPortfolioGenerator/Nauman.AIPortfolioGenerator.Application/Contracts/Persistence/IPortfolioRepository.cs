using System;
using Nauman.AIPortfolioGenerator.Domain;
using System.Collections.Generic;
using System.Text;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence.common;

namespace Nauman.AIPortfolioGenerator.Application.Contracts.Persistence
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
    }
}
