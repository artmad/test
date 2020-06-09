using System;
using JobScheduler.Quartz;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace MegaNote
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    DataScheduler.Start(serviceProvider);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            host.Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .Build();

    }
}
