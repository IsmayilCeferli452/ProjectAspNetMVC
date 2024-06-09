using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using Project.ViewModels;

namespace Project.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public CoursesController(ICategoryService categoryService,
                                ICourseService courseService,
                                IStudentService studentService)
        {
            _categoryService = categoryService;
            _courseService = courseService;
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var courses = await _courseService.GetAllAsync();
            var students = await _studentService.GetAllAsync();

            CourseVM response = new CourseVM()
            {
                Categories = categories,
                Courses = courses,
                Students = students
            };

            return View(response);
        }
    }
}
