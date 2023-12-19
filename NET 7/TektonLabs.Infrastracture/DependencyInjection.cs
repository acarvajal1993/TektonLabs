using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Infrastracture.Data;
using TektonLabs.Services.Mocks.Mockapi;

namespace TektonLabs.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TektonLabsContext>(options => options.UseSqlServer(configuration.GetConnectionString("TektonLabsEntities")));

            //Servicios externos
            services.AddTransient<IMockapiClient, MockapiClient>();

            return services;
        }
    }
}
