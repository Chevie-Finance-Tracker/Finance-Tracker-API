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

        public async Task<Spending?> UpdateAsync(int id, Spending spending)
        {
            var existingSpending = await _dbContext.Spendings.FindAsync(id);

            if (existingSpending == null)
            {
                return null;
            }

            // We do this because automapper puts the spending domain model as 0
            spending.Id = existingSpending.Id;

            _dbContext.Entry(existingSpending).CurrentValues.SetValues(spending);

            await _dbContext.SaveChangesAsync();

            return existingSpending;
        }

        public async Task<Spending?> DeleteAsync(int id)
        {
            var existingSpending = await _dbContext.Spendings.FindAsync(id);

            if (existingSpending == null)
            {
                return null;
            }

            _dbContext.Spendings.Remove(existingSpending);
            await _dbContext.SaveChangesAsync();

            return existingSpending;
        }

        public async Task<List<Spending>> GetByUserAsync(string userId)
        {
            return await _dbContext.Spendings.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
