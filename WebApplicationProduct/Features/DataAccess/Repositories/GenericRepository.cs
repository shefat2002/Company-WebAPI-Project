

using WebApplicationProduct.Features.DataAccess.MicroServiceDbContext;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;

namespace WebApplicationProduct.Features.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericeRepository<T> where T : class
    {
        protected readonly CompanyDbContext _context;
        public GenericRepository(CompanyDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
          await _context.Set<T>().AddAsync(entity);
         
        }

        public async Task<T> GetBy(int id)
        {
           return await _context.Set<T>().FindAsync(id);

        }
    }
}
