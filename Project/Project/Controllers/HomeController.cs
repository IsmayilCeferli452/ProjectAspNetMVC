using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Project.Services.Interfaces;
using Project.ViewModels;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarouselService _carouselService;

        public HomeController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public async Task<IActionResult> Index()
        {
            var carousels = await _carouselService.GetAllAsync();

            HomeVM response = new HomeVM()
            {
                Carousels = carousels
            };

            return View(response);
        }
    }
}
