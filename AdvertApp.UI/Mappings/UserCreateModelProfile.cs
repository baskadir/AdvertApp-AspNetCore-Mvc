using AdvertApp.Dtos;
using AdvertApp.UI.Models;
using AutoMapper;

namespace AdvertApp.UI.Mappings
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<AppUserCreateDto, UserCreateModel>().ReverseMap();
        }
    }
}
