using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class FinanceTrackerAuthDbContext : IdentityDbContext<IdentityUser>
    {
        public FinanceTrackerAuthDbContext(DbContextOptions<FinanceTrackerAuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}
