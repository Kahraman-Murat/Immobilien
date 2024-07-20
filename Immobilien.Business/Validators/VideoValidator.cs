using FluentValidation;
using Immobilien.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Business.Validators
{
    public class VideoValidator:AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video Url Bos birakilamaz");
            RuleFor(x => x.VideoUrl).MinimumLength(10).WithMessage("Minimum 10 karakterden olusan Url yaziniz.");
        }
    }
}
