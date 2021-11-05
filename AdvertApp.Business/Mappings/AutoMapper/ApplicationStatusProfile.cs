using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;

namespace AdvertApp.Business.Mappings.AutoMapper
{
    public class ApplicationStatusProfile : Profile
    {
        public ApplicationStatusProfile()
        {
            CreateMap<ApplicationStatus, ApplicationStatusListDto>().ReverseMap();
        }
    }
}
