using FinanceTracker.Models.Domain;

namespace FinanceTracker.Repositories
{
    public interface ISpendingRepository
    {
        Task<List<Spending>> GetAllAsync();
        Task<List<Spending>> GetAllByUserAsync(string userId);
        Task<Spending?> GetById(int id);
        Task<Spending> CreateAsync(Spending spending);
        Task<Spending?> UpdateAsync(int id, Spending spending);
        Task<Spending?> DeleteAsync(int id);
    }
}
