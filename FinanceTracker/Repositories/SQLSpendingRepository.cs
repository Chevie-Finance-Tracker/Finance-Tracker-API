using FinanceTracker.Data;
using FinanceTracker.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Repositories
{
    public class SQLSpendingRepository : ISpendingRepository
    {
        private readonly FinanceTrackerDbContext _dbContext;

        public SQLSpendingRepository(FinanceTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Spending>> GetAllAsync()
        {
            return await _dbContext.Spendings.ToListAsync();
        }

        public async Task<Spending?> GetById(int id)
        {
            return await _dbContext.Spendings.FindAsync(id);
        }

        public async Task<Spending> CreateAsync(Spending spending)
        {
            await _dbContext.Spendings.AddAsync(spending);
            await _dbContext.SaveChangesAsync();

            return spending;
        }
    }
}
