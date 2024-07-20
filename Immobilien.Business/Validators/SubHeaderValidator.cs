using FluentValidation;
using Immobilien.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Business.Validators
{
    public class SubHeaderValidator : AbstractValidator<SubHeader>
    {
        public SubHeaderValidator()
        {
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adres bos birakilamaz");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta adresi bos birakilamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Gecerli bir E-Posta adresi yaziniz.");

            //RuleFor(x => x.Facebook).NotEmpty().WithMessage("Facebook Adresi bos birakilamaz");

            //RuleFor(x => x.Twitter).NotEmpty().WithMessage("Twitter Adresi bos birakilamaz");

            //RuleFor(x => x.Linkedin).NotEmpty().WithMessage("Linkedin Adresi bos birakilamaz");

            //RuleFor(x => x.Instagram).NotEmpty().WithMessage("Instagram Adresi bos birakilamaz");
            
        }
    }
}