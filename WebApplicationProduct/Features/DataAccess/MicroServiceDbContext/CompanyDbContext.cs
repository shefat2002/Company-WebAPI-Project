
using Microsoft.EntityFrameworkCore;
using WebApplicationProduct.Features.DomainModels;

namespace WebApplicationProduct.Features.DataAccess.MicroServiceDbContext
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext()
        {
            
        }
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options) 
        {
            Console.WriteLine($"AppDbContext created: {GetHashCode()}");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }

        
        public DbSet<Company> Companies { get; set; }

        public DbSet<Branch> BranchesDb { get; set; }

    }
}
