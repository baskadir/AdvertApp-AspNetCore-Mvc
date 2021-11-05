using AdvertApp.Common.Enums;
using AdvertApp.Dtos;
using FluentValidation;

namespace AdvertApp.Business.ValidationRules
{
    public class ApplicationCreateDtoValidator : AbstractValidator<ApplicationCreateDto>
    {
        public ApplicationCreateDtoValidator()
        {
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.ApplicationStatusId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("Bir cv dosyası eklemelisiniz.");
            RuleFor(x => x.PhotoPath).NotEmpty().WithMessage("Fotoğraf eklemelisiniz.");
            RuleFor(x => x.PostponeEndDate).NotEmpty().When(x=>x.MilitaryStatusId == (int)MilitaryStatusType.Postpone).WithMessage("Tecil tarihi girilmesi zorunludur.");
        }
    }
}
