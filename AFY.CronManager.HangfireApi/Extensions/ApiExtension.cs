namespace AFY.CronManager.HangfireApi.Extensions
{
    public static class ApiExtension
    {
        internal static IHostBuilder AddConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            });
            return hostBuilder;
        }
    }
}
