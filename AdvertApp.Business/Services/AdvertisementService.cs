using AdvertApp.Business.Interfaces;
using AdvertApp.Common.Enums;
using AdvertApp.Common.ResponseObjects;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>,IAdvertisementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdvertisementService(IUnitOfWork unitOfWork,IMapper mapper,IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator):base(unitOfWork,mapper,createDtoValidator,updateDtoValidator)
        {
            // Dependency injection burada çalışır. burada DI ile alınan örnekler base'e gönderilir.
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResponse<IEnumerable<AdvertisementListDto>>> GetActivesAsync()
        {
            var data = await _unitOfWork.GetRepository<Advertisement>().GetAllAsync(x => x.Status, x => x.CreatedDate, OrderByType.Descending);
            var dto = _mapper.Map<IEnumerable<AdvertisementListDto>>(data);
            return new Response<IEnumerable<AdvertisementListDto>>(ResponseType.Success, dto);
        }
    }
}
