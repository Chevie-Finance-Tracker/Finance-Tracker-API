using FinanceTracker.Models.DTO;
using FluentValidation;

namespace FinanceTracker.Models.Validations
{
    public class SpendingRequestDTOValidator : AbstractValidator<AddSpendingRequestDTO>
    {
        public SpendingRequestDTOValidator()
        {
            RuleFor(x => x.Name).Length(1, 100);
            RuleFor(x => x.Description).Length(1, 250);
        }
    }

    public class UpdateSpendingRequestDTOValidator : AbstractValidator<UpdateSpendingRequestDTO>
    {
        public UpdateSpendingRequestDTOValidator()
        {
            RuleFor(x => x.Name).Length(1, 100);
            RuleFor(x => x.Description).Length(1, 250);
        }
    }
}
