using WebApplicationProduct.Features.DataAccess.MicroServiceDbContext;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;
using WebApplicationProduct.Features.DomainModels;

namespace WebApplicationProduct.Features.DataAccess.Repositories
{
    public class BranchRepository: GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(CompanyDbContext context): base(context)
        {
            
        }
    }
}
