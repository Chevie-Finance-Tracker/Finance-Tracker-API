using AutoMapper;
using FinanceTracker.Data;
using FinanceTracker.Models.Domain;
using FinanceTracker.Models.DTO;
using FinanceTracker.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpendingRepository _spendingRepository;

        public SpendingsController(IMapper mapper, ISpendingRepository spendingRepository)
        {
            _mapper = mapper;
            _spendingRepository = spendingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var spendingsDomain = await _spendingRepository.GetAllAsync();

            var spendingsDTO = _mapper.Map<List<SpendingDTO>>(spendingsDomain);

            return Ok(spendingsDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var spendingDomain = await _spendingRepository.GetById(id);

            if (spendingDomain == null)
            {
                return NotFound();
            }

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomain);

            return Ok(spendingDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSpendingRequestDTO addSpendingRequestDTO)
        {
            var spendingDomainmodel = _mapper.Map<Spending>(addSpendingRequestDTO);

            spendingDomainmodel = await _spendingRepository.CreateAsync(spendingDomainmodel);

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomainmodel);

            return Ok(spendingDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSpendingRequestDTO updateSpendingRequestDTO)
        {
            var spendingDomainModel = _mapper.Map<Spending>(updateSpendingRequestDTO);

            spendingDomainModel = await _spendingRepository.UpdateAsync(id, spendingDomainModel);

            if (spendingDomainModel == null)
            {
                return NotFound();
            }

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomainModel);

            return Ok(spendingDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var spendingDomainModel = await _spendingRepository.DeleteAsync(id);

            if (spendingDomainModel == null)
            {
                return NotFound();
            }

            var spendingDTO = _mapper.Map<SpendingDTO>(spendingDomainModel);

            return Ok(spendingDTO);
        }
    }
}
