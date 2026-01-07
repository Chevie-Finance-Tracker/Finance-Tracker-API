using FinanceTracker.Models.DTO;

namespace FinanceTracker.Services.Interfaces
{
    public interface ISpendingService
    {
        Task<List<SpendingDTO>> GetUserSpendingsAsync(string userId);
        Task<SpendingDTO> CreateSpendingAsync(string userId, AddSpendingRequestDTO addSpendingRequestDTO);
        Task<SpendingDTO?> UpdateSpendingAsync(string userId, int id, UpdateSpendingRequestDTO updateSpendingRequestDTO);
        Task<SpendingDTO?> DeleteSpendingAsync(string userId, int id);
    }
}
