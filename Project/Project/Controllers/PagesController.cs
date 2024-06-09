using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using Project.ViewModels;

namespace Project.Controllers
{
    public class PagesController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly IStudentService _studentService;

        public PagesController(IInstructorService instructorService, IStudentService studentService)
        {
            _instructorService = instructorService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var instructors = await _instructorService.GetAllAsync();

            TeamVM response = new TeamVM()
            {
                Instructors = instructors
            };

            return View(response);
        }

        public async Task<IActionResult> Testimonal()
        {
            var students = await _studentService.GetAllAsync();

            TestimonalVM response = new TestimonalVM()
            {
                Students = students
            };

            return View(response);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
