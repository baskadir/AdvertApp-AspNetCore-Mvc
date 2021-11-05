using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;

namespace AdvertApp.Business.Mappings.AutoMapper
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
        }
    }
}
