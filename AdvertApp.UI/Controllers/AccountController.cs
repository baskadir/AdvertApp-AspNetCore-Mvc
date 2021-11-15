using AdvertApp.Business.Interfaces;
using AdvertApp.Common.Enums;
using AdvertApp.Dtos;
using AdvertApp.UI.Extensions;
using AdvertApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _createModelValidator;
        private readonly IValidator<UserPasswordUpdateModel> _passwordUpdateModelValidator;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> createModelValidator, IMapper mapper, IAppUserService appUserService, IValidator<UserPasswordUpdateModel> passwordUpdateModelValidator)
        {
            _genderService = genderService;
            _createModelValidator = createModelValidator;
            _mapper = mapper;
            _appUserService = appUserService;
            _passwordUpdateModelValidator = passwordUpdateModelValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _createModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                // ilgili kullanıcının rollerini çekme
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);
                var claims = new List<Claim>();
                if (roleResult.ResponseType == ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }
                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", result.Message);
            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Update()
        {
            var userId = Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var user = await _appUserService.GetByIdAsync<AppUserUpdateDto>(userId);
            return View(user.Data);
        }

        [Authorize(Roles ="Member")]
        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateDto dto)
        {
            var response = await _appUserService.UpdateAsync(dto);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin,Member")]
        public IActionResult ChangePassword()
        {
            return View(new UserPasswordUpdateModel());
        }

        [Authorize(Roles ="Admin,Member")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPasswordUpdateModel model)
        {
            var result = _passwordUpdateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var userId = Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var response = await _appUserService.UpdatePasswordAsync(model.OldPassword, model.NewPassword, userId);
                if(response.ResponseType == ResponseType.Success)
                    return RedirectToAction("Update");
                ModelState.AddModelError("", response.Message);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }
    }
}
