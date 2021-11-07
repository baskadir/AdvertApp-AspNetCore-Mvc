﻿using AdvertApp.Business.Extensions;
using AdvertApp.Business.Interfaces;
using AdvertApp.Common.Enums;
using AdvertApp.Common.ResponseObjects;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertApp.Business.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ApplicationCreateDto> _createDtoValidator;
        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<ApplicationCreateDto> createDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<ApplicationCreateDto>> CreateAsync(ApplicationCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var controlData = await _unitOfWork.GetRepository<Application>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
                if (controlData == null)
                {
                    var createdApplication = _mapper.Map<Application>(dto);
                    await _unitOfWork.GetRepository<Application>().CreateAsync(createdApplication);
                    await _unitOfWork.SaveChangesAsync();
                    return new Response<ApplicationCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new()
                {
                    new()
                    {
                        ErrorMessage = "İlana daha önce başvurduğunuz için tekrar başvuramazsınız.",
                        PropertyName = ""
                    }
                };
                return new Response<ApplicationCreateDto>(dto, errors);
            }
            return new Response<ApplicationCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IEnumerable<ApplicationListDto>> GetListAsync(ApplicationStatusType type)
        {
            var query = _unitOfWork.GetRepository<Application>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.ApplicationStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x => x.Gender).Where(x => x.ApplicationStatusId == (int)type).ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationListDto>>(list);
        }

        public async Task SetStatusAsync(int applicationId,ApplicationStatusType type)
        {
            var query = _unitOfWork.GetRepository<Application>().GetQuery();
            var entity = await query.SingleOrDefaultAsync(x => x.Id == applicationId);
            entity.ApplicationStatusId = (int)type;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}