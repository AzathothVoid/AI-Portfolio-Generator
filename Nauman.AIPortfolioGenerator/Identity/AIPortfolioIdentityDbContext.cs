using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class AIPortfolioIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AIPortfolioIdentityDbContext(DbContextOptions<AIPortfolioIdentityDbContext> options) : base(options)
        {
                    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
