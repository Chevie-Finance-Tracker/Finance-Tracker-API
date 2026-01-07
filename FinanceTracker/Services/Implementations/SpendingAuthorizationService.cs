using FinanceTracker.Models.Domain;
using FinanceTracker.Repositories;

namespace FinanceTracker.Services.Implementations
{
    public class SpendingAuthorizationService
    {
        private readonly ISpendingRepository _spendingRepository;

        public SpendingAuthorizationService(ISpendingRepository spendingRepository)
        {
            _spendingRepository = spendingRepository;
        }

        public async Task IsSpendingOwnedByUser(string userId, int id)
        {
            var existingSpending = await _spendingRepository.GetById(id);

            if (existingSpending == null)
                throw new KeyNotFoundException("Spending not found");

            if (existingSpending.UserId != userId)
            {
                throw new UnauthorizedAccessException("You do not own this spending");
            }
        }
    }
}
