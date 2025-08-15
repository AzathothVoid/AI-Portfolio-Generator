using Microsoft.EntityFrameworkCore;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private readonly AIPortfolioDbContext _dbContext;

        public SectionRepository(AIPortfolioDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Section>> GetAllByPortfolioAsync(int id)
        {
            var section = await _dbContext.Sections
                .Include(q => q.Portfolio)
                .Where(q => q.Portfolio.Id == q.Portfolio.Id)
                .ToListAsync();

            return section;
        }
    }
}
