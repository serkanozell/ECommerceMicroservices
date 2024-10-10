namespace Catalog.Application.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<Category> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}