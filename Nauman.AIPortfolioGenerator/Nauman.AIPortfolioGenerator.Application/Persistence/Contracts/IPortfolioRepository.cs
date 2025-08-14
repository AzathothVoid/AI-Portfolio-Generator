using System;
using Nauman.AIPortfolioGenerator.Domain;
using System.Collections.Generic;
using System.Text;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts.common;

namespace Nauman.AIPortfolioGenerator.Application.Persistence.Contracts
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
    }
}
