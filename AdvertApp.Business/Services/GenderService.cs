using AdvertApp.Business.Interfaces;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;
using FluentValidation;

namespace AdvertApp.Business.Services
{
    public class GenderService : Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>, IGenderService
    {
        public GenderService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator) : base(unitOfWork,mapper,createDtoValidator,updateDtoValidator)
        {
        }
    }
}
