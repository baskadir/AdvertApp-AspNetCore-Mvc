using AdvertApp.Common.Enums;
using AdvertApp.Common.ResponseObjects;
using AdvertApp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Interfaces
{
    public interface IApplicationService
    {
        Task<IResponse<ApplicationCreateDto>> CreateAsync(ApplicationCreateDto dto);
        Task<IEnumerable<ApplicationListDto>> GetListAsync(ApplicationStatusType type);
        Task SetStatusAsync(int applicationId, ApplicationStatusType type);
        Task<bool> CheckUserApplicationAsync(int advertId, int userId);
        Task<IEnumerable<ApplicationListDto>> GetUserApplications(int userId);
        Task<IResponse> RemoveAsync(int id);
        int GetApplicationCountByAdvert(int advertId);
        int GetTotalApplicatonCount();
    }
}
