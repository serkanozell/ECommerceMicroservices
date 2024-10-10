using System.Reflection;

namespace Catalog.Persistance.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}