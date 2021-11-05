using AdvertApp.Dtos;
using FluentValidation;

namespace AdvertApp.Business.ValidationRules
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.School).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
