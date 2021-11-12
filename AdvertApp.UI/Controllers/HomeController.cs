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
        public HomeController(IAboutService aboutService, IAdvertisementService advertisementService, IApplicationService applicationService)
        {
            _aboutService = aboutService;
            _advertisementService = advertisementService;
            _applicationService = applicationService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _aboutService.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> AdvertList()
        {
            var response = await _advertisementService.GetActivesAsync();
            foreach (var item in response.Data)
            {
                item.ApplicationCount = _applicationService.GetApplicationCount(item.Id);
            }
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
    }
}
