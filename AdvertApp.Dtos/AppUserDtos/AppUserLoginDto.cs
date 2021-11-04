using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
