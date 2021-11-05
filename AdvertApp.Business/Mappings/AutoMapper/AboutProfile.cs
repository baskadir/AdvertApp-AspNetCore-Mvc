using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;

namespace AdvertApp.Business.Mappings.AutoMapper
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutCreateDto>().ReverseMap();
            CreateMap<About, AboutUpdateDto>().ReverseMap();
            CreateMap<About, AboutListDto>().ReverseMap();
        }
    }
}
