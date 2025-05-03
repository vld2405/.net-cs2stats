using Microsoft.Extensions.Configuration;
using CS2Stats.Infrastructure.Config.Models;

namespace CS2Stats.Infrastructure.Config
{
    public class AppConfig
    {
        public static bool ConsoleLogQueries = true;
        public static ConnectionStringsSettings? ConnectionStrings { get; set; }

        public static void Init(IConfiguration configuration)
        {
            Configure(configuration);
        }

        private static void Configure(IConfiguration configuration)
        {
            ConnectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStringsSettings>();
        }
    }
}
