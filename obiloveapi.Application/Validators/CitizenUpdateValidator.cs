// obiloveapi.Application/Validators/UserUpdateValidator.cs
using FluentValidation;
using obiloveapi.Application.DTOs.User;

namespace obiloveapi.Application.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);
            RuleFor(x => x.FirstName)
                .NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName)
                .NotEmpty().MaximumLength(100);
            // Add rules for the rest of the fields as needed.
        }
    }
}
