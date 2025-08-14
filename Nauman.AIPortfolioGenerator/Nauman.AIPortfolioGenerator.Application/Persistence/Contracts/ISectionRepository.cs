using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts.common;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Persistence.Contracts
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<IReadOnlyList<Section>> GetAllByPortfolioAsync(int id);
    }
}
