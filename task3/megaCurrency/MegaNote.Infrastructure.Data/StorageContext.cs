using MegaNote.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace MegaNote.Infrastructure.Data
{
    public class StorageContext: DbContext
    {
        public DbSet<RateEntry> RateEntries { get; set; }
        public StorageContext()
        {
            Database.EnsureCreated();
        }

        public StorageContext(DbContextOptions o) : base(o)
        {
        }
    }
}
