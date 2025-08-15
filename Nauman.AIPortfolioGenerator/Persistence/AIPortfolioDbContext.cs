using Microsoft.EntityFrameworkCore;
using Nauman.AIPortfolioGenerator.Domain;
using Nauman.AIPortfolioGenerator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AIPortfolioDbContext : DbContext
    {
        public AIPortfolioDbContext(DbContextOptions<AIPortfolioDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AIPortfolioDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableWithBaseEntity>())
            {
                entry.Entity.UpdatedAt = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
