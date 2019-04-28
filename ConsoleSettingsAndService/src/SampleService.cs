using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CoreSample
{
    public class SampleService : IHostedService
    {
        private readonly IConfiguration _configuration;

        public SampleService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("MainSetting: " + _configuration["MainSetting"]);
            Console.WriteLine("AppSettings - Value: " + _configuration.GetSection("AppSettings")["Value"]);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}