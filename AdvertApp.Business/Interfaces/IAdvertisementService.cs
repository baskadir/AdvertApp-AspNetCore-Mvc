using AdvertApp.Common.ResponseObjects;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<IResponse<IEnumerable<AdvertisementListDto>>> GetActivesAsync();
    }
}
