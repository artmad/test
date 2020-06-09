using MegaNote.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MagaNote.Domain.Interfaces;
using MegaNote.Infrastructure.Data.Repositories;
using MegaNote.Infrastructure.Business;
using MegaNote.Services.Interfaces;
using JobScheduler.Quartz;
using JobScheduler.Workers;
using MegaCurrency.Services.Interfaces;
using MegaCurrency.Infrastructure.Business;

namespace MegaNote
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<StorageContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<JobFactory>();
            services.AddScoped<DataJob>();
            services.AddScoped<ICurrencyRateWorker, CurrencyRateWorker>();

            RegisterRepositories(services);
            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRateEntryService, RateEntryService>();
            services.AddScoped<ICurrencyReportService, CurrencyReportService>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IRateEntryRepository, RateEntryRepository>();
        }
    }
}
