namespace Catalog.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        Task Save();
    }
}