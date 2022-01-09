using AdvertApp.Common.ResponseObjects;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser> 
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);
        Task<IResponse<IEnumerable<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
        Task<IResponse> UpdatePasswordAsync(string oldPassword, string newPassword, int id);
        Task<bool> CheckUserNameExist(string userName);
    }
}
