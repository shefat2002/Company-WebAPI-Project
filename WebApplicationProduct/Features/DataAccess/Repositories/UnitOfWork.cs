
using WebApplicationProduct.Features.DataAccess.MicroServiceDbContext;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;

namespace AenEnterprise.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(CompanyDbContext context, ILogger<UnitOfWork> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public int Save()
        {
            _logger.LogInformation("Saving changes...");
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving changes.");
                throw;
            }
        }

        public async Task<int> SaveAsync()
        {
            _logger.LogInformation("Saving changes asynchronously...");
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving changes asynchronously.");
                throw;
            }
        }
    }



}
