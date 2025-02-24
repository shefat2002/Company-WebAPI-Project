namespace WebApplicationProduct.Features.DataAccess.RepositoryInterface
{
    public interface IGenericeRepository<T> where T : class
    {
        Task Add(T entity);
        Task<T> GetBy(int id);
    }
}
