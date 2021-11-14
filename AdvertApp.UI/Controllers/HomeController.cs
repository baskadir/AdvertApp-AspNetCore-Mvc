using AdvertApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AdvertApp.UI.Extensions;
using AdvertApp.Dtos;
using System.Linq;
using System.Security.Claims;
using System;

namespace AdvertApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IApplicationService _applicationService;
        private readonly IAppUserService _appUserService;
        public HomeController(IAboutService aboutService, IAdvertisementService advertisementService, IApplicationService applicationService, IAppUserService appUserService)
        {
            _aboutService = aboutService;
            _advertisementService = advertisementService;
            _applicationService = applicationService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _aboutService.GetAllAsync();
            ViewBag.TotalAdvertisementCount = _advertisementService.GetQuery().Count();
            ViewBag.TotalUserCount = _appUserService.GetQuery().Count();
            ViewBag.TotalApplicationCount = _applicationService.GetTotalApplicatonCount();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> AdvertList()
        {
            var response = await _advertisementService.GetActivesAsync();
            response.Data.ToList().ForEach(x =>
            {
                x.ApplicationCount = _applicationService.GetApplicationCountByAdvert(x.Id);
            });
            return this.ResponseView(response);
        }

        public async Task<IActionResult> AdvertDetail(int id)
        {
            var response = await _advertisementService.GetByIdAsync<AdvertisementListDto>(id);
            if (User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                response.Data.IsApplied = await _applicationService.CheckUserApplicationAsync(id,userId);
            }
            return this.ResponseView(response);
        }

        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
