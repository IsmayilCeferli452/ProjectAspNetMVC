using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Project.Services.Interfaces;
using Project.ViewModels;
using Project.ViewModels.Categories;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();

            CourseVM response = new CourseVM()
            {
                Courses = courses
            };

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var course = await _courseService.GetByIdAsync((int)id);

            if (course is null) return NotFound();

            await _courseService.DeleteAsync(course);

            return RedirectToAction(nameof(Index));
        }
    }
}
