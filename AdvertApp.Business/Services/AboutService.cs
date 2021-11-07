using AdvertApp.Business.Interfaces;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;
using FluentValidation;

namespace AdvertApp.Business.Services
{
    public class AboutService : Service<AboutCreateDto, AboutUpdateDto, AboutListDto, About>, IAboutService
    {
        public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AboutCreateDto> createDtoValidator, IValidator<AboutUpdateDto> updateDtoValidator) : base(unitOfWork, mapper, createDtoValidator, updateDtoValidator)
        {
        }
    }
}
