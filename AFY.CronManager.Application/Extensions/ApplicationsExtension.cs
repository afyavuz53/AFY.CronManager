using AFY.CronManager.Application.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Application.Extensions
{
    public static class ApplicationsExtension
    {
        public static IServiceCollection AddAplicationOptionConfigs(this IServiceCollection services, IConfiguration config)
        {
            return services.Configure<DatabaseConfig>(config.GetSection(nameof(DatabaseConfig)));
        }
    }
}
