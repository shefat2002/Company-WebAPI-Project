
namespace WebApplicationProduct.Features.DataAccess.RepositoryInterface
{
    public interface IUnitOfWork 
    {
        Task<int> SaveAsync();
    }
}
