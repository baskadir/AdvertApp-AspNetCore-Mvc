using AdvertApp.UI.Models;
using FluentValidation;

namespace AdvertApp.UI.ValidationRules
{
    public class UserPasswordUpdateModelValidator : AbstractValidator<UserPasswordUpdateModel>
    {
        public UserPasswordUpdateModelValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Eski şifre alanı boş geçilemez.");
            RuleFor(x => x.NewPassword).Equal(x => x.ConfirmNewPassword).WithMessage("Şifreler birbiri ile aynı değil.");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Yeni şifre boş geçilemez.");
            RuleFor(x => x.NewPassword).MinimumLength(4).WithMessage("Yeni şifreniz en az dört karakterli olmalıdır.");
        }
    }
}
