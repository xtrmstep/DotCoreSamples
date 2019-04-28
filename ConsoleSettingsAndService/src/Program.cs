using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreSample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await new HostBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    if (args != null)
                    {
                        // enviroment from command line
                        // e.g.: dotnet run --environment "Staging"
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var environment = context.HostingEnvironment;
                    builder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<SampleService>();
                })
                .RunConsoleAsync(CancellationToken.None);
        }
    }
}
