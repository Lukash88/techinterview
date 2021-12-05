using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestWebAPI.DataAccess.Entities;

namespace TestWebAPI.DataAccess
{
    public class TestWebAPIStorageContext : DbContext
    {
        public TestWebAPIStorageContext(DbContextOptions<TestWebAPIStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());        
    }
}