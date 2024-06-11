using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using Project.ViewModels.Abouts;

namespace Project.Controllers
{
    public class AboutController : Controller
    {
        private readonly IInformationService _informationService;
        private readonly IAboutService _aboutService;
        private readonly IInstructorService _instructorService;

        public AboutController(IInformationService informationService,
                               IAboutService aboutService,
                               IInstructorService instructor)
        {
            _informationService = informationService;
            _aboutService = aboutService;
            _instructorService = instructor;
        }
        public async Task<IActionResult> Index()
        {
            var informations = await _informationService.GetAllAsync();
            var about = await _aboutService.GetAllAsync();
            var instructors = await _instructorService.GetAllAsync();

            AboutVM response = new AboutVM()
            {
                About = about,
                Instructors = instructors,
                Informations = informations
            };

            return View(response);
        }
    }
}
