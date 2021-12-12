using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heuristics.TechEval.Core.Models.Validation
{
    public class MemberValidation : AbstractValidator<Member>
    {
        public MemberValidation()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Member Name can not be Empty")
                .MaximumLength(50).WithMessage("Member Name can not be greater then 50 characters");
            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Member Email can not be empty.")
                .EmailAddress().WithMessage("You must have a valid Email Address.");
        }
    }
}
