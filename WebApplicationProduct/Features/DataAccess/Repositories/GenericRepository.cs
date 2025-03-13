using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplicationProduct.Features.DataAccess.MicroServiceDbContext;

namespace WebApplicationProduct.Features.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CompanyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CompanyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }
        public async Task<T> GetBy(int id, params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _dbSet;
            foreach(var item in Includes)
            {
                query = query.Include(item);
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            //return await _context.Set<T>().FindAsync(id);

        }
        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        
    }
}
