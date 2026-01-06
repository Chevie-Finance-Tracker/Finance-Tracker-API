using FinanceTracker.Models.Domain;

namespace FinanceTracker.Repositories
{
    public interface ISpendingRepository
    {
        Task<List<Spending>> GetAllAsync();
        Task<Spending?> GetById(int id);
        Task<Spending> CreateAsync(Spending spending);
    }
}
