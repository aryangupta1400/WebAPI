using FluentValidation;
using Model.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DeveloperModels
{
    public class DeveloperValidation : AbstractValidator<Intern>
    {
        public DeveloperValidation()
        {
            RuleFor(i => i.InternName).NotEmpty().WithMessage("{PropertyName} is a REQURIED field.");
        }
    }
}
