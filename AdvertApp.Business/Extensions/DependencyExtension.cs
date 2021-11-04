using AdvertApp.DataAccess.Context;
using AdvertApp.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertApp.Business.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
