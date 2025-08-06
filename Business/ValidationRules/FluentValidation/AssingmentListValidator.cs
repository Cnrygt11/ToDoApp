using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AssingmentListValidator : AbstractValidator<AssignmentList>
    {
        public AssingmentListValidator()
        {
            RuleFor(al => al.Name).NotEmpty().WithMessage(Messages.AssignmentListNameEmpty);
            RuleFor(al => al.Name).MinimumLength(2).WithMessage(Messages.AssignmentListNameInvalid);
            RuleFor(al => al.Name).MaximumLength(50).WithMessage(Messages.AssignmentListNameInvalid);
        }
    }
}
