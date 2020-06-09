using System.Data.Entity;
using TPT.Entities;

namespace TPT
{
    public class StorageContext : DbContext
    {
        public StorageContext() : this("name=DefaultConnection")
        {
        }

        public StorageContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ArticleCommonTable> ArticleCommonTable { get; set; }
        public DbSet<ArticleFirstTypeTable> ArticleFirstTypeTable { get; set; }
        public DbSet<ArticleSecondTypeTable> ArticleSecondTypeTable { get; set; }
    }
}