using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;

namespace AdvertApp.Business.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
        }
    }
}
