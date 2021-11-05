using AdvertApp.Dtos;
using FluentValidation;

namespace AdvertApp.Business.ValidationRules
{
    public class AboutUpdateDtoValidator : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
