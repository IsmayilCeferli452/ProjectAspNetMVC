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
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;
        private readonly IInstructorService _instructorService;
        private readonly IStudentService _studentService;

        public HomeController(ICarouselService carouselService, 
                              IInformationService informationService,
                              IAboutService aboutService,
                              ICategoryService categoryService,
                              ICourseService courseService,
                              IInstructorService instructorService,
                              IStudentService studentService)
        {
            _carouselService = carouselService;
            _informationService = informationService;
            _aboutService = aboutService;
            _categoryService = categoryService;
            _courseService = courseService;
            _instructorService = instructorService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var carousels = await _carouselService.GetAllAsync();
            var informations = await _informationService.GetAllAsync();
            var about = await _aboutService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            var courses = await _courseService.GetAllAsync();
            var instructors = await _instructorService.GetAllAsync();
            var students = await _studentService.GetAllAsync();

            HomeVM response = new HomeVM()
            {
                Carousels = carousels,
                Informations = informations,
                About = about,
                Categories = categories,
                Courses = courses,
                Instructors = instructors,
                Students = students
            };

            return View(response);
        }
    }
}
