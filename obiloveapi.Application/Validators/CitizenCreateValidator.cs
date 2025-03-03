// obiloveapi.Application/Validators/UserCreateValidator.cs
using FluentValidation;
using obiloveapi.Application.DTOs.User;

namespace obiloveapi.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(100);
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(100);
            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("A valid email is required");
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(15);
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required")
                .MaximumLength(250);
            RuleFor(x => x.ProvinceId)
                .GreaterThan(0).WithMessage("Province selection is required");
            // Additional rules for CityId and BarangayId can be added similarly.
        }
    }
}
