using AdvertApp.Business.Extensions;
using AdvertApp.Business.Interfaces;
using AdvertApp.Common.Enums;
using AdvertApp.Common.ResponseObjects;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos;
using AdvertApp.Entities.Concrete;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>, IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IValidator<AppUserLoginDto> loginDtoValidator) : base(unitOfWork, mapper, createDtoValidator, updateDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await _unitOfWork.GetRepository<AppUser>().CreateAsync(user);

                await _unitOfWork.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _unitOfWork.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }
            return new Response<AppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var result = _loginDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var user = await _unitOfWork.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username);
                if(user != null && BCrypt.Net.BCrypt.Verify(dto.Password,user.Password))
                {
                    var userDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, userDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı ya da şifreniz hatalı");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı ve şifre boş olamaz.");
        }

        public async Task<IResponse<IEnumerable<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _unitOfWork.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
                return new Response<IEnumerable<AppRoleListDto>>(ResponseType.NotFound, "Rol bulunamadı");
            var dto = _mapper.Map<IEnumerable<AppRoleListDto>>(roles);
            return new Response<IEnumerable<AppRoleListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse> UpdatePasswordAsync(string oldPassword, string newPassword, int id)
        {
            var user = await _unitOfWork.GetRepository<AppUser>().FindAsync(id);
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {
                return new Response(ResponseType.ValidationError, "Eski şifrenizi yanlış girdiniz.");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _unitOfWork.GetRepository<AppUser>().Update(user);
            await _unitOfWork.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }
    }
}
