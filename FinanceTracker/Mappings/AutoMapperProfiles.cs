using AutoMapper;
using FinanceTracker.Models.Domain;
using FinanceTracker.Models.DTO;

namespace FinanceTracker.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Spending, SpendingDTO>().ReverseMap();
            CreateMap<AddSpendingRequestDTO, Spending>().ReverseMap();
        }
    }
}
