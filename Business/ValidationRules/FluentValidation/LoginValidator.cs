using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {

            RuleFor(u => u.Username)
                .NotEmpty().WithMessage(Messages.UsernameCannotBeEmpty);
                

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(Messages.PasswordCannotBeEmpty);
        }
    }
}
