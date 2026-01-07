using AutoMapper;
using FinanceTracker.Models.Domain;
using FinanceTracker.Models.DTO;
using FinanceTracker.Repositories;
using FinanceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Services.Implementations
{

    public class SpendingService : ISpendingService
    {
        private readonly IMapper _mapper;
        private readonly ISpendingRepository _spendingRepository;
        private readonly SpendingAuthorizationService _spendingAuthorizationService;

        public SpendingService(
            IMapper mapper, 
            ISpendingRepository spendingRepository, 
            SpendingAuthorizationService spendingAuthorizationService
            )
        {
            _mapper = mapper;
            _spendingRepository = spendingRepository;
            _spendingAuthorizationService = spendingAuthorizationService;
        }

        public async Task<List<SpendingDTO>> GetUserSpendingsAsync(string userId)
        {
            var spendingsDomain = await _spendingRepository.GetAllByUserAsync(userId);

            var spendingsDTO = _mapper.Map<List<SpendingDTO>>(spendingsDomain);

            return spendingsDTO;
        }

        public async Task<SpendingDTO> CreateSpendingAsync(string userId, AddSpendingRequestDTO addSpendingRequestDTO)
        {
            var spendingDomainmodel = _mapper.Map<Spending>(addSpendingRequestDTO);

            spendingDomainmodel.UserId = userId;

            spendingDomainmodel = await _spendingRepository.CreateAsync(spendingDomainmodel);

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomainmodel);

            return spendingDTO;
        }

        public async Task<SpendingDTO?> UpdateSpendingAsync(string userId, int id, UpdateSpendingRequestDTO updateSpendingRequestDTO)
        {
            await _spendingAuthorizationService.IsSpendingOwnedByUser(userId, id);

            var spendingDomainModel = _mapper.Map<Spending>(updateSpendingRequestDTO);

            spendingDomainModel = await _spendingRepository.UpdateAsync(id, spendingDomainModel);

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomainModel);

            return spendingDTO;
        }

        public async Task<SpendingDTO?> DeleteSpendingAsync(string userId, int id)
        {
            await _spendingAuthorizationService.IsSpendingOwnedByUser(userId, id);

            var spendingDomainModel = await _spendingRepository.DeleteAsync(id);

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomainModel);

            return spendingDTO;
        }
    }
}
