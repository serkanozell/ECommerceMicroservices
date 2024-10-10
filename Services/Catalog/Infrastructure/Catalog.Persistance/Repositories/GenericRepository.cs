using Catalog.Domain.Common;
using System.Linq.Expressions;

namespace Catalog.Persistance.Repositories
{
    public class GenericRepository<T>(ApplicationDbContext _dbContext) : IGenericRepository<T> where T : BaseEntity, new()
    {
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }
        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return entities;
        }

        public async Task DeleteAsync(T entity) => Table.Remove(entity);

        public void DeleteRangeAsync(List<T> entities) => Table.RemoveRange(entities);


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null) => expression == null ? GetQueryableAllActive().ToList() : GetQueryableAllActive().Where(expression).ToList();

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression) => await GetQueryableAllActive().Where(expression).FirstOrDefaultAsync();

        public async Task<T?> GetByIdAsync(Guid id) => await GetQueryableAllActive().FirstOrDefaultAsync(e => e.Id == id);

        public async Task UpdateAsync(T entity) => Table.Update(entity).State = EntityState.Modified;

        public IQueryable<T> GetQueryable() => Table.Where(e => !e.IsDeleted);
        public IQueryable<T> GetQueryableAllActive() => GetQueryable().Where(e => e.IsActive);
    }
}