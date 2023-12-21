using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Infrastracture.Data;
using TektonLabs.Infrastracture.Repositories.Interfaces;
using TektonLabs.Infrastracture.Repositories;
using TektonLabs.Services.Mocks.Mockapi;
using TektonLabs.Infrastracture.CacheService;


namespace TektonLabs.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TektonLabsContext>(options => options.UseSqlServer(configuration.GetConnectionString("TektonLabsEntities")));

            //External services
            services.AddScoped<IMockapiClient, MockapiClient>();


            //Repositories
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //Services
            services.AddScoped<IProductCacheService, ProductCacheService>();

            return services;
        }
    }
}
