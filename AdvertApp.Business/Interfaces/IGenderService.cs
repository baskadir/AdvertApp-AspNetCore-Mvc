using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;

namespace AdvertApp.Business.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {
    }
}
