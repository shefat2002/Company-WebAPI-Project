

using WebApplicationProduct.Features.DataAccess.MicroServiceDbContext;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;
using WebApplicationProduct.Features.DomainModels;

namespace WebApplicationProduct.Features.DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyDbContext context):base(context)
        {
            
        }
    }
}
