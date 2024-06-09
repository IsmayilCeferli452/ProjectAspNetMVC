using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using Project.ViewModels;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarouselService _carouselService;
        private readonly IInformationService _informationService;
        private readonly IAboutService _aboutService;

        public HomeController(ICarouselService carouselService, 
                              IInformationService informationService,
                              IAboutService aboutService)
        {
            _carouselService = carouselService;
            _informationService = informationService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var carousels = await _carouselService.GetAllAsync();
            var informations = await _informationService.GetAllAsync();
            var aboutUs = await _aboutService.GetAllAsync();


            HomeVM response = new HomeVM()
            {
                Carousels = carousels,
                Informations = informations,
                AboutUs = aboutUs
            };

            return View(response);
        }
    }
}
