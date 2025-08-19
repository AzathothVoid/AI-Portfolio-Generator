using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AIPortfolioIdentityDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("AIPortfolioIdentityDbConectionString")
                ));
            return services;
        }
    }
}
