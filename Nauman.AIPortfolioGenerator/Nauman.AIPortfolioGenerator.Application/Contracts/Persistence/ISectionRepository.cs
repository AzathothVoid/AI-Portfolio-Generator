using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence.common;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Contracts.Persistence
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<IReadOnlyList<Section>> GetAllByPortfolioAsync(int id);
    }
}
