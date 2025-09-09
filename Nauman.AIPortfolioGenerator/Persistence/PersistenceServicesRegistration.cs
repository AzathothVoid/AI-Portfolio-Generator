using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence.common;
using Persistence.Repositories;
using Persistence.Repositories.Common;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AIPortfolioDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("AIPortfolioMainDbConectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();

            return services;
        }
    }
}
