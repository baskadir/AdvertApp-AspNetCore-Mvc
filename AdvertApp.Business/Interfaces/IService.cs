using AdvertApp.Common.ResponseObjects;
using AdvertApp.Dtos.Interfaces;
using AdvertApp.Entities.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Interfaces
{
    public interface IService<CreateDto,UpdateDto,ListDto,T> 
        where CreateDto : class,IDto,new()
        where UpdateDto : class,IUpdateDto,new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<IEnumerable<ListDto>>> GetAllAsync();
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse> RemoveAsync(int id);
    }
}
