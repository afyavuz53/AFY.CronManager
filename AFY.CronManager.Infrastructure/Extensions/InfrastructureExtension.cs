using AFY.CronManager.Application.Extensions;
using AFY.CronManager.Application.Interfaces.Repositories;
using AFY.CronManager.Application.Interfaces.Services;
using AFY.CronManager.Infrastructure.Repositories;
using AFY.CronManager.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAplicationOptionConfigs(configuration);

            #region Repositories
            services.AddScoped<IReadRepository, ReadRepository>();
            services.AddScoped<IWriteRepository, WriteRepository>();
            #endregion

            #region Services
            services.AddScoped<IMyActivityService, MyActivityService>();
            #endregion

            return services;
        }
    }
}
