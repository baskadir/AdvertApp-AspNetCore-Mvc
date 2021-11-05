using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;

namespace AdvertApp.Business.Mappings.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationCreateDto>().ReverseMap();
            CreateMap<Application, ApplicationListDto>().ReverseMap();
        }
    }
}
