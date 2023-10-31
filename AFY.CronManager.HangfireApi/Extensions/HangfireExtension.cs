using AFY.CronManager.Application.Interfaces.Services;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using Hangfire.MySql;

namespace AFY.CronManager.HangfireApi.Extensions
{
    public static class HangfireExtension
    {
        internal static IServiceCollection AddHangfireConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = configuration.GetSection("DatabaseConfig:HangfireDbConnectionString").Value;
            services.AddHangfire(h => h
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseStorage(new MySqlStorage(connectionStrings, new MySqlStorageOptions()
            {
                PrepareSchemaIfNecessary = true,
                QueuePollInterval = TimeSpan.FromSeconds(10)
            })))
                .AddHangfireServer(option =>
                {
                    option.ServerName = "JnrCoder";
                });
            return services;
        }

        internal static IApplicationBuilder UseMyHangfireApplication(this IApplicationBuilder app)
        {
            return app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HanfireAuthorizationFilter() }
            });
        }

        internal static void AddMyJob()
        {
            RecurringJob.AddOrUpdate<IMyActivityService>("my-job", x => x.MyFunction(), "*/2 * * * *");
        }
    }

    internal class HanfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true; // Geçici olarak herkesi yetkilendiriyoruz, canlı uygulamalarda buraya güvenlik ayarları eklenir.
        }
    }
}
