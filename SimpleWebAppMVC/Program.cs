using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SimpleWebAppMVC
{
    public class Program
    {
        /**
         * We need to use IHostBuilder to override when integration testing
         */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>();
            });

        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
    }
}
