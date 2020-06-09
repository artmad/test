using JobScheduler.Workers;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Quartz
{
    public class DataJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public DataJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var currencyRateWorker = scope.ServiceProvider.GetService<ICurrencyRateWorker>();

                await currencyRateWorker.TrackCurrency();
            }
        }
    }
}
