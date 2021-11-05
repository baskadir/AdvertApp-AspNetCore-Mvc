using AdvertApp.Dtos;
using FluentValidation;

namespace AdvertApp.Business.ValidationRules
{
    public class AboutCreateDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
