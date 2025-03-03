// obiloveapi.Application/Validators/CitizenUpdateValidator.cs
using FluentValidation;
using obiloveapi.Application.DTOs.Citizen;

namespace obiloveapi.Application.Validators
{
    public class CitizenUpdateValidator : AbstractValidator<CitizenUpdateRequest>
    {
        public CitizenUpdateValidator()
        {
            RuleFor(x => x.CitizenId)
                .GreaterThan(0);
            RuleFor(x => x.FirstName)
                .NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName)
                .NotEmpty().MaximumLength(100);
            // Add rules for the rest of the fields as needed.
        }
    }
}
