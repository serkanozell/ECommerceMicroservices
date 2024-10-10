namespace Catalog.Persistance.Repositories
{
    public class UnitOfWork(ApplicationDbContext _dbContext) : IUnitOfWork
    {
        private ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);


        public void Dispose() => _dbContext.Dispose();

        public async Task Save() => await _dbContext.SaveChangesAsync();
    }
}