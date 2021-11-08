using AdvertApp.UI.Models;
using FluentValidation;

namespace AdvertApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        // TODO : Burayı sonra düzenle
        public UserCreateModelValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum tarihinizi seçmelisiniz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Yaşadığınız şehir bilgisini boş geçemezsiniz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresini doğru formatta girmelisiniz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim bilgisini boş geçemezsiniz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("İsim bilgisini boş geçemezsiniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarasını boş geçemezsiniz.");
            RuleFor(x => x.School).NotEmpty().WithMessage("Okul bilgisini boş geçemezsiniz.");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi yapmalısınız.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en az üç karakterden oluşmalıdır.");
            RuleFor(x => new
            {
                x.Username,
                x.FirstName
            }).Must(x => CanNotFirstName(x.Username, x.FirstName)).WithMessage("Kullanıcı adı isminiz ile aynı olamaz.").When(x => x.Username != null && x.FirstName != null);

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifreyi boş geçemezsiniz.");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Şifre en az dört karakterli olmalıdır.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler birbiri ile aynı değil.");
            RuleFor(x => x.Password).NotEqual(x => x.FirstName).WithMessage("Şifre isim ile aynı olamaz.");
            RuleFor(x => x.Password).NotEqual(x => x.Username).WithMessage("Şifre kullanıcı adı ile aynı olamaz.");
            RuleFor(x => x.Password).NotEqual(x => x.LastName).WithMessage("Şifre soyisim ile aynı olamaz.");
        }

        private bool CanNotFirstName(string username, string firstName)
        {
            return username != firstName;
        }
    }
}
