using AutoMapper;
using FinanceTracker.Data;
using FinanceTracker.Models.Domain;
using FinanceTracker.Models.DTO;
using FinanceTracker.Models.Validations;
using FinanceTracker.Repositories;
using FinanceTracker.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpendingsController : ControllerBase
    {
        private readonly ISpendingService _spendingService;

        public SpendingsController(ISpendingService spendingService)
        {
            _spendingService = spendingService;
        }

        /// <summary>
        /// Get logged in user's spendings
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetByUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return Unauthorized();

            var spendingsDTO = _spendingService.GetUserSpendingsAsync(userId);

            return Ok(spendingsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSpendingRequestDTO addSpendingRequestDTO)
        {
            SpendingRequestDTOValidator validator = new SpendingRequestDTOValidator();

            ValidationResult results = validator.Validate(addSpendingRequestDTO);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return Unauthorized();

            var spendingDTO = _spendingService.CreateSpendingAsync(userId, addSpendingRequestDTO);

            return Ok(spendingDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSpendingRequestDTO updateSpendingRequestDTO)
        {
            UpdateSpendingRequestDTOValidator validator = new UpdateSpendingRequestDTOValidator();

            ValidationResult results = validator.Validate(updateSpendingRequestDTO);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return Unauthorized();

            var spendingDTO = await _spendingService.UpdateSpendingAsync(userId, id, updateSpendingRequestDTO);

            return Ok(spendingDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return Unauthorized();

            var spendingDTO = await _spendingService.DeleteSpendingAsync(userId, id);

            return Ok(spendingDTO);
        }
    }
}
