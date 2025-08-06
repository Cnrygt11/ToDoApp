using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email)
            .NotEmpty().WithMessage(Messages.EmailCannotBeEmpty)
            .EmailAddress().WithMessage(Messages.InvalidEmailFormat);

            RuleFor(u => u.Username)
                .NotEmpty().WithMessage(Messages.UsernameCannotBeEmpty)
                .MinimumLength(3).WithMessage(Messages.UsernameTooShort);

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(Messages.PasswordCannotBeEmpty)
                .MinimumLength(6).WithMessage(Messages.PasswordTooShort);
        }
    }
}
