using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace MegaNote.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StorageContext>
    {
        public StorageContext CreateDbContext(string[] args)
        {
            var appSettingsPath = Directory.GetCurrentDirectory() + "/../MegaNote/appsettings.Development.json";

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(appSettingsPath).Build();
            var builder = new DbContextOptionsBuilder<StorageContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new StorageContext(builder.Options);
        }
    }
}
