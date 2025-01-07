using System.Linq.Expressions;

namespace RepositoryPattern.API.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> Get(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}
