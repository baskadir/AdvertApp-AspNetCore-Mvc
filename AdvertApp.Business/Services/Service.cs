using AdvertApp.Business.Extensions;
using AdvertApp.Business.Interfaces;
using AdvertApp.Common.Enums;
using AdvertApp.Common.ResponseObjects;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos.Interfaces;
using AdvertApp.Entities.Abstract;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        public Service(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _unitOfWork.GetRepository<T>().CreateAsync(createdEntity);
                await _unitOfWork.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success,dto);
            }
            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<IEnumerable<ListDto>>> GetAllAsync()
        {
            var data = await _unitOfWork.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<IEnumerable<ListDto>>(data);
            return new Response<IEnumerable<ListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _unitOfWork.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<IDto>(ResponseType.NotFound, $"{id} idsine sahip bir data bulunamadı.");
            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _unitOfWork.GetRepository<T>().FindAsync(id);
            if (data == null)
                return new Response(ResponseType.NotFound, $"{id} idsine sahip bir data bulunamadı.");
            _unitOfWork.GetRepository<T>().Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _unitOfWork.GetRepository<T>().FindAsync(dto.Id);
                if (unchangedData == null)
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} idsine sahip bir data bulunamadı");
                var data = _mapper.Map<T>(dto);
                _unitOfWork.GetRepository<T>().Update(data, unchangedData);
                await _unitOfWork.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            return new Response<UpdateDto>(dto,result.ConvertToCustomValidationError());
        }
    }
}
