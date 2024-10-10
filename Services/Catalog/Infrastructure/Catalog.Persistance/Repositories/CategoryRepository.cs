namespace Catalog.Persistance.Repositories
{
    public class CategoryRepository(ApplicationDbContext _dbContext) : GenericRepository<Category>(_dbContext), ICategoryRepository
    {
    }
}