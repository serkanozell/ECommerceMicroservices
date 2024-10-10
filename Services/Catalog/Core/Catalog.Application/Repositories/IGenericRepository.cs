using System.Linq.Expressions;

namespace Catalog.Application.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void DeleteRangeAsync(List<T> entities);
        IQueryable<T> GetQueryableAllActive();
    }
}