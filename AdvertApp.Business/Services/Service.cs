using AdvertApp.Business.Interfaces;
using AdvertApp.Common.ResponseObjects;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        // TODO: Fluent Validation
        // TODO: Automapper
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IEnumerable<ListDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
