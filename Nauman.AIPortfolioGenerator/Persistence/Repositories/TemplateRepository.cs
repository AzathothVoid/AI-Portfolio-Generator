using Microsoft.EntityFrameworkCore;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Domain;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        private readonly AIPortfolioDbContext _dbContext;

        public TemplateRepository(AIPortfolioDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
