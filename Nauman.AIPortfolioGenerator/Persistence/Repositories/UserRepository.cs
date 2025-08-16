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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AIPortfolioDbContext _dbContext;

        public UserRepository(AIPortfolioDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangePremiumStatus(User user, bool premiumStatus)
        {
            user.isPremium = premiumStatus;
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
