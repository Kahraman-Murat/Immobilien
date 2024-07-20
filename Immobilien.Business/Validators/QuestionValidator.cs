using FluentValidation;
using Immobilien.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Business.Validators
{
    public class QuestionValidator:AbstractValidator<Quest>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage("Soru Bos birakilamaz");
            RuleFor(x => x.Question).MinimumLength(10).WithMessage("Minimum 10 karakterden olusan soru yaziniz.");
            RuleFor(x => x.Question).MaximumLength(200).WithMessage("Maximum 200 karakteri gecmeyen soru yaziniz.");
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Cevap Bos birakilamaz");
            RuleFor(x => x.Answer).MinimumLength(10).WithMessage("Minimum 10 karakterden olusan cevap yaziniz.");
            RuleFor(x => x.Answer).MaximumLength(200).WithMessage("Maximum 200 karakteri gecmeyen cevap yaziniz.");
        }
    }
}
