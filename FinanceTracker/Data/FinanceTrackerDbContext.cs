using FinanceTracker.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class FinanceTrackerDbContext : DbContext
    {
        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Spending> Spendings { get; set; }
    }
}
