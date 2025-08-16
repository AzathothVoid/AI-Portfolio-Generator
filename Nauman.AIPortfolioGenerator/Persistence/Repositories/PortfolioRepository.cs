using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        private readonly AIPortfolioDbContext _dbContext;

        public PortfolioRepository(AIPortfolioDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
