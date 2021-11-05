using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;

namespace AdvertApp.Business.Interfaces
{
    public interface IAboutService : IService<AboutCreateDto,AboutUpdateDto,AboutListDto,About>
    {
    }
}
