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
    public class AssignmentValidator : AbstractValidator<Assignment>
    {
        public AssignmentValidator()
        {
            RuleFor(a => a.AssignmentName).NotEmpty();
            RuleFor(a => a.AssignmentName).MinimumLength(2).WithMessage(Messages.AssignmentNameInvalid);
            RuleFor(a => a.AssignmentName).MaximumLength(50).WithMessage(Messages.AssignmentNameInvalid); ;
            RuleFor(a => a.DeadlineDate).Must(BeAValidDate).WithMessage("Assignment deadline invalid.");
        }
        private bool BeAValidDate(DateTime deadline)
        {
            return deadline >= DateTime.UtcNow;
        }
    }
}
