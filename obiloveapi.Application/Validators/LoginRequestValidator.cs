// obiloveapi.Application/Validators/LoginRequestValidator.cs
using FluentValidation;
using obiloveapi.Application.DTOs.Auth;

namespace obiloveapi.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
