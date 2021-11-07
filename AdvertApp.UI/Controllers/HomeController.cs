using AdvertApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AdvertApp.UI.Extensions;
using AdvertApp.Dtos;

namespace AdvertApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IAdvertisementService _advertisementService;
        public HomeController(IAboutService aboutService, IAdvertisementService advertisementService)
        {
            _aboutService = aboutService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _aboutService.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> AdvertList()
        {
            var response = await _advertisementService.GetActivesAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> AdvertDetail(int id)
        {
            var response = await _advertisementService.GetByIdAsync<AdvertisementListDto>(id);
            return this.ResponseView(response);
        }
    }
}
