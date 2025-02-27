
using System.Linq.Expressions;

namespace WebApplicationProduct.Features.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task<T> GetBy(int id, params Expression<Func<T, object>>[] Includes);
        Task Update(T entity);
    }
}